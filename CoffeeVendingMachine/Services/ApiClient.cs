using CoffeeVendingMachine.Shared.Interfaces;
using CoffeeVendingMachine.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Services
{
    public static class ApiClient
    {
        public async static Task<IEnumerable<ICoffee>> GetCoffeesAsync(HttpClient client)
        {
            var api = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Api")["StarbucksApi"];

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await client.GetAsync(api);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var coffees = JsonSerializer.Deserialize<List<ThirdPartyCoffee>>(responseBody, options);

                    if (coffees.Count > 0)
                    {
                        return coffees;
                    }
                    else
                    {
                        Console.WriteLine("Third party coffee request failed. Choose another option");
                        return new List<ICoffee>();
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("Third party coffee request failed. Choose another option");
                    return new List<ICoffee>();
                }
            }
            else
            {
                Console.WriteLine("Third party coffee request failed. Choose another option");
                return new List<ICoffee>();
            }
        }
    }
}

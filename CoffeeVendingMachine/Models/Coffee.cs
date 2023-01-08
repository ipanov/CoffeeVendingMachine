using CoffeeVendingMachine.Shared.Interfaces;
using System.Collections.Generic;
 
namespace CoffeeVendingMachine.Models
{
    public class Coffee : ICoffee
    {
        public string Type { get; set; }
        public List<string> Characteristics { get; set; }

        public Coffee() 
        {   
            Type= "Basic Coffee";
            Characteristics = new List<string>();
        }

        public string GetDescription()
        {
            return "Basic Coffee";
        }
    }
}

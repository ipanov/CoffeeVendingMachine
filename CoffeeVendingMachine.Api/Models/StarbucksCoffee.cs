using CoffeeVendingMachine.Shared.Interfaces;
using System.Collections.Generic;

namespace StarbucksCoffee.Api.Models
{
    public class StarbucksCoffee : ICoffee
    {
        public string Type { get; set; }
        public List<string> Characteristics { get; set; }

        public StarbucksCoffee()
        {
            Type = "Starbucks Coffee";
            Characteristics = new List<string>();
        }

        public string GetDescription()
        {
            return $"{Type} Starbucks Cofee with, {string.Join(", ", Characteristics)}";
        }
    }
}

using System.Collections.Generic;
using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Shared.Models
{
    public class ThirdPartyCoffee : ICoffee
    {
        public string Type { get; set; }
        public List<string> Characteristics { get; set; }

        public ThirdPartyCoffee()
        {

        }

        public string GetDescription()
        {
            return $"{Type}, {string.Join(", ", Characteristics)}";
        }
    }
}

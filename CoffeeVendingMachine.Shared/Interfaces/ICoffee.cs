using System.Collections.Generic;

namespace CoffeeVendingMachine.Shared.Interfaces
{
    public interface ICoffee
    {
        public string Type { get; set; }
        public List<string> Characteristics { get; set; }
        public string GetDescription();
    }
}


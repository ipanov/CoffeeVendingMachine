using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public class Americano : BaseCoffee
    {
        public Americano(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = "Americano";
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("Caramelle");
            Characteristics.Add("Creamer");
        }
    }
}

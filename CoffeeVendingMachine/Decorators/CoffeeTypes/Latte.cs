using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public class Latte : BaseCoffee, ICoffee
    {
        public Latte(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = "Latte";
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("has a single dose of milk");
            Characteristics.Add("one pack of sugar");
        }
    }
}

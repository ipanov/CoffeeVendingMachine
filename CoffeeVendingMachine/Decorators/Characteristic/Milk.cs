using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristics
{
    public class Milk : CharacteristicDecorator
    {
        public Milk(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("has a single dose of milk");
        }
    }
}

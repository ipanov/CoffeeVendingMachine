using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristic
{
    public class Milk : CharacteristicDecorator
    {
        public Milk(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = decoratedCoffee.Type;
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("has a single dose of milk");
        }
    }
}

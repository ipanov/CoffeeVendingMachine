using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristic
{
    public class Sugar : CharacteristicDecorator
    {
        public Sugar(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = decoratedCoffee.Type;
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("single pack of sugar");
        }
    }
}

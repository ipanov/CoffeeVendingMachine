using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristic
{
    public class MoreMilk : CharacteristicDecorator
    {
        public MoreMilk(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {

            Type = decoratedCoffee.Type;
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("has a double dose of milk");
        }
    }
}

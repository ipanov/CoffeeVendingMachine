using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristic
{
    public class MoreSugar : CharacteristicDecorator
    {
        public MoreSugar(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = decoratedCoffee.Type;
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("two pack of sugar");
        }
    }
}

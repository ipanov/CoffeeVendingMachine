using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristics
{
    public class Sugar : CharacteristicDecorator
    {
        public Sugar(ICoffee decoratedCoffee) :base(decoratedCoffee)
        {
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("one pack of sugar");
        }
    }
}

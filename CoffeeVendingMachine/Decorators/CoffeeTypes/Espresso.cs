using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public class Espresso : BaseCoffee
    {
        public Espresso(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = "Espresso";
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("one pack of sugar");
        }
    }
}

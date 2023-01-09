using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public class Cappucino : BaseCoffee
    {
        public Cappucino(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = "Cappucino";
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("one pack of sugar");
        }
    }
}
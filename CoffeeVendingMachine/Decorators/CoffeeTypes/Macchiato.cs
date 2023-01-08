using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public class Macchiato : BaseCoffee, ICoffee
    {
        public Macchiato(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = "Macchiato";
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("one pack of sugar");
        }
    }
}

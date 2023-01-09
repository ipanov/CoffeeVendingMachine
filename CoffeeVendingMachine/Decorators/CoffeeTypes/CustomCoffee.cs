using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public class CustomCoffee : BaseCoffee
    {
        public CustomCoffee(ICoffee decoratedCoffee, string type) : base(decoratedCoffee)
        {
            Type = string.Format("{0} {1}", type, decoratedCoffee.Type);
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
        }
    }
}

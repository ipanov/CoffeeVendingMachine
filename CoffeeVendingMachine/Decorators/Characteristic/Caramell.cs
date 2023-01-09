using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Shared.Interfaces;
 
namespace CoffeeVendingMachine.Decorators.Characteristic
{
    public class Caramell : CharacteristicDecorator
    {
        public Caramell(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = decoratedCoffee.Type;
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("has a caramell topping");
        }
    }
}

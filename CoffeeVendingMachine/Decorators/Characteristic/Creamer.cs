using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Shared.Interfaces;

namespace CoffeeVendingMachine.Decorators.Characteristic
{
    public class Creamer : CharacteristicDecorator
    {
        public Creamer(ICoffee decoratedCoffee) : base(decoratedCoffee)
        {
            Type = decoratedCoffee.Type;
            decoratedCoffee.Characteristics.ForEach(c => Characteristics.Add(c));
            Characteristics.Add("with creamer");
        }
    }
}

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Factories
{
  public class PizzaFactory : IPizzaFactory
  {
    public APizza Create<T>() where T: APizza, new()
    {
      return new T();
    }

  }
}
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Interfaces
{
  public interface IPizzaFactory
  {
    APizza Create<T>() where T : APizza, new();

  }
}
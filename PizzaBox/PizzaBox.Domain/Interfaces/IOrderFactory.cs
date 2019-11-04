using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Interfaces
{
  public interface IOrderFactory
  {
    AOrder Create<T>() where T : AOrder, new();

  }
}
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using Xunit;
using Moq;

namespace PizzaBox.Testing.Specs
{
  public class DefaultPizzaSpec {
    DefaultPizza testPizza;

    public DefaultPizzaSpec()
    {
      testPizza = new DefaultPizza();
    }

    [Fact]          // call before the execution Test_AudioObject, log the test (listen 104.3 FM)
    public void Test_DefaultPizzaObject()
    {
      double cost = 7.00; // Default Pizza should cost 7 dollars

      Assert.True(cost == testPizza.Cost);
    }

  }
}

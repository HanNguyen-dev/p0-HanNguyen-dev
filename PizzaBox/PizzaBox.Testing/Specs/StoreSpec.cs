using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using Xunit;
using Moq;

namespace PizzaBox.Testing.Specs
{
  public class StoreSpec {
    Store testStore;

    public StoreSpec()
    {
      testStore = new Store( new string[]{"store1", "store2"});

    }

    [Fact]          // call before the execution Test_AudioObject, log the test (listen 104.3 FM)
    public void Test_StoreObject()
    {
      testStore.MyStore = 2;

      Assert.True(testStore.MyStore == 2);
      Assert.True(testStore.MyAddress == "store2");
    }

  }
}

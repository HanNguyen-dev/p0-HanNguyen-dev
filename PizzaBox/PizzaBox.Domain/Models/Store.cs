using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public string[] stores;
    public int MyStore { get; set; }
    public string MyAddress {get; set; }

    public Store()
    {
      stores = StoreRepository.stores;
    }

    public void PrintStores()
    {
      int count = 1;
      foreach (string store in stores)
      {
        string index = System.Convert.ToString(count);
        System.Console.WriteLine($"[{index}] " + store);
        count++;
      }
    }
  }
}
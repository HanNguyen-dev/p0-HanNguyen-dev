using System;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    private int storeID;
    public string[] stores;
    public int MyStore {
      get { return storeID; }
      set { storeID = value;
            MyAddress = stores[value - 1]; }
    }
    public string MyAddress { get; set; }

    public Store(string[] storeRepo)
    {
      stores = storeRepo;
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
    public void SelectStore()
    {
      Console.WriteLine("Please select from the following stores:");
      PrintStores();
      int selection;

      if (int.TryParse(Console.ReadLine(), out selection)) {

        if (selection > 0 && selection < 4) {
          MyStore = selection;
          Console.WriteLine("You have selected:");
          Console.WriteLine(MyAddress);
        } else {
          Console.WriteLine("Invalid entry please try again.\n");
          SelectStore();
        }
      } else {
        Console.WriteLine("Invalid entry please try again.\n");
        SelectStore();
      }
    }

    public string GetAddressByID(int i) {
      return stores[i - 1];
    }
  }
}
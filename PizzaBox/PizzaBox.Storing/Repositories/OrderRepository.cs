using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private const string FILE = "PizzaBox.Storing/Repositories/orders.json";

    public static Hashtable readData()
    {
      Hashtable orderData = new Hashtable();

      var theOrder = new Transaction{orderNum=1, user="han", location=3, pizzas=new List<string> {"wow", "cool"}, cost=10.22};
      var jsonSting = JsonConvert.SerializeObject(theOrder);
      Console.WriteLine(jsonSting);

      // StreamReader reader = new StreamReader(FILE);
      // List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(reader.ReadToEnd());
      // foreach(Account account in accounts)
      // {
      //   userPass.Add(account.username, account.password);
      // }

      return orderData;
    }

    public static void writeData(Hashtable newUserPass)
    {
      // ICollection keys = newUserPass.Keys;
      // List<Account> updatedList = new List<Account>();

      // foreach(string key in keys)
      // {
      //   System.Console.WriteLine($"{key} - {newUserPass[key]}");
      //   updatedList.Add( new Account{username=key, password=Convert.ToString(newUserPass[key])} );
      // }
      // string jsonString = JsonConvert.SerializeObject(updatedList);

      // StreamWriter writer = new StreamWriter(FILE);
      // writer.Write(jsonString);
      // writer.Close();
    }

    internal class Transaction
    {
      public int orderNum { get; set; }
      public string user { get; set; }
      public int location { get; set; }
      public List<string> pizzas { get; set; }
      public double cost { get; set; }
    }
  }
}
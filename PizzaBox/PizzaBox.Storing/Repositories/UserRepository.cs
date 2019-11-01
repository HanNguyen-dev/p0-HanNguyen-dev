using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace PizzaBox.Storing.Repositories {

  public class UserRepository
  {
    private const string FILE = "PizzaBox.Storing/Repositories/users.json";

    User one;

    public static Hashtable readData()
    {
      Hashtable userPass = new Hashtable();

      StreamReader reader = new StreamReader(FILE);
      List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(reader.ReadToEnd());
      foreach(Account account in accounts)
      {
        userPass.Add(account.username, account.password);
      }

      return userPass;
    }

    public static void writeData(Hashtable newUserPass)
    {
      ICollection keys = newUserPass.Keys;
      List<Account> updatedList = new List<Account>();

      foreach(string key in keys)
      {
        System.Console.WriteLine($"{key} - {newUserPass[key]}");
        updatedList.Add( new Account{username=key, password=Convert.ToString(newUserPass[key], storeID=1, orderTime)} );
      }
      string jsonString = JsonConvert.SerializeObject(updatedList);

      StreamWriter writer = new StreamWriter(FILE);
      writer.Write(jsonString);
      writer.Close();
    }

    internal class Account
    {
      public string username { get; set; }
      public string password { get; set; }
      public int storeID { get; set; }
      public DateTime orderTime { get; set; }
    }
  }
}
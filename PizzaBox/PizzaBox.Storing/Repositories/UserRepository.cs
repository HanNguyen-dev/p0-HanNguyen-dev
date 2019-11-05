using System;
using System.Collections;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Connectors;


namespace PizzaBox.Storing.Repositories {

  public class UserRepository
  {
    // private const string FILE = "PizzaBox.Storing/Repositories/users.xml";

    public static List<Account> accounts = new List<Account>();


    public static void Create()
    {
      // List<Account> accounts = new List<Account>();

      accounts.Add(new Account{username="cool", password="working", storeID=3, orderTime=new DateTime(2019, 11, 4, 18, 31, 0)});
      accounts.Add(new Account{username="hot", password="working", storeID=1, orderTime=new DateTime(2019, 3, 1)});
      accounts.Add(new Account{username="bob", password="working", storeID=2, orderTime=new DateTime(2019, 11, 3)});
    }

    public static Hashtable readData()
    {

      Hashtable userAccount = new Hashtable();
      accounts = UserFileConnector.ReadXml();

      foreach(Account account in accounts)
      {
        userAccount.Add(account.username, account);
      }

      return userAccount;
    }

    public static void writeData(Hashtable newUserPass)
    {
      ICollection accounts = newUserPass.Values;
      List<Account> updatedList = new List<Account>();

      foreach(Account account in accounts)
      {
        updatedList.Add(account);
      }

      // accounts = updatedList;
      UserFileConnector.WriteXml(updatedList);

    }

  }
}
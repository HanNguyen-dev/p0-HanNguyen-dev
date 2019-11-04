using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AUser : IAccount
  {
    protected Account theAccount;
    public string username
    { get { return theAccount.username; } }
    public string password
    { get { return theAccount.password; } }
    public int LastStore
    { get { return theAccount.storeID; } }
    public DateTime LastOrderTime
    { get { return theAccount.orderTime; }
      set { theAccount.orderTime = value; }   }
    public void ViewOrderHistory(List<Transaction> list)
    {
      int zero = 0;

      foreach (Transaction order in list)
      {
        if (order.user == username)
        {
          if (zero == 0)
          {
            Console.WriteLine("Your past order(s)\n");
            zero++;
          }

          Console.WriteLine($"Order #: {Convert.ToString(order.orderNum)}");
          // missing location
          string pizzasString = "";
          foreach (string pizza in order.pizzas)
          {
            pizzasString = pizzasString + " " + pizza + ",";
          }

          Console.WriteLine($"Pizza(s): {pizzasString.TrimEnd(',')}");
          Console.WriteLine("Cost: ${0:N2}\n", order.cost);

        }

      }

    }
  }
}
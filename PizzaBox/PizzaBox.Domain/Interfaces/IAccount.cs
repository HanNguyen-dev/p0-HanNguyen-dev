using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IAccount
  {
    string username { get; }
    string password { get; }
    int LastStore { get; }
    DateTime LastOrderTime { get; }
    void ViewOrderHistory(List<Transaction> list);

  }
}
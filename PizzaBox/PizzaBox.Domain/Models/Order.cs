using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Factories;
using static PizzaBox.Domain.Delegates.OrderRepoDelegate;

namespace PizzaBox.Domain.Models
{
  public class Order : AOrder
  {
    public Store CurrentStore { get; set; }
    public List<APizza> MyPizzas { get; set; }
    public List<Transaction> theOrders;
    public double TotalCost { get; set; }
  }
}
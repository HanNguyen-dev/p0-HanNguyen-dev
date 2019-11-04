using System;

namespace PizzaBox.Domain.Models
{
  public class Account
  {
    public string username { get; set; }
    public string password { get; set; }
    public int storeID { get; set; }
    public DateTime orderTime { get; set; }
  }
}
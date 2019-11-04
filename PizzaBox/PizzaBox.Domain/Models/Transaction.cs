using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Transaction
  {
    public int orderNum { get; set; }
    public string user { get; set; }
    public int storeID { get; set; }
    public List<string> pizzas { get; set; }
    public double cost { get; set; }
  }

}




using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public User CurrentUser { get; set; }
    public Store CurrentStore { get; set; }
    public List<APizza> MyPizzas { get; set; }
  }
}
using System.Collections;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Domain.Delegates
{
  public abstract class OrderRepoDelegate
  {
    public delegate int ReadOrderNumberDelegate();
    public delegate void WriteOrderNumberDelegate(int orderNumber);
    public delegate void WriteDelegate(List<Transaction> orderData);
  }
}

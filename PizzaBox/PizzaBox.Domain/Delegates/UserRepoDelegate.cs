using System.Collections;

namespace PizzaBox.Domain.Delegates
{
  public abstract class UserRepoDelegate
  {
    public delegate void WriteDelegate(Hashtable data);
  }
}

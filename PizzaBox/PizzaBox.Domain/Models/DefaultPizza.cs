namespace PizzaBox.Domain.Models
{
  public class DefaultPizza : APizza
  {

    public DefaultPizza() {
      this.Size = "large";
      this.Crust = "hand_tossed";
      this.AddTopping("pepperoni");
      this.AddTopping("green_peppers");
    }
  }
}
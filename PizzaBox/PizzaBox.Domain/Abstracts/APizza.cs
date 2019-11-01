using System;
using System.Collections;

namespace PizzaBox.Domain.Models
{
  public abstract class APizza : IFood
  {

    private string size;
    private string crust;
    public double Cost { get; private set; }

    private double baseCost = 0;

    public Hashtable Toppings = new Hashtable();
    private ArrayList myToppings = new ArrayList();

    public string Crust {
      get { return crust; }
      set {
        if (value == "hand_tossed" || value == "pan" || value == "thin") {
          crust = value;
        }
      }
    }

    public string Size
    { get { return size; }
      set {
        if (value == "small") {
          size = "small";
          baseCost = 3.00;
        } else if (value == "medium") {
          size = "medium";
          baseCost = 4.00;
        } else if (value == "large") {
          size = "large";
          baseCost = 5.00;
        }
      }
    }


    public APizza()
    {
      Toppings.Add("pepperoni", 1.50);
      Toppings.Add("bacon", 1.50);
      Toppings.Add("sausage", 1.50);
      Toppings.Add("black_olives", .50);
      Toppings.Add("green_peppers", .50);
      Toppings.Add("mushrooms", .50);

    }

    public void AddTopping(string topping)
    {
      if (myToppings.Count < 5) {
        myToppings.Add(topping);
      } else {
        System.Console.WriteLine("You can only have a maximum of 5 toppings per pizza.");
      }
      ComputeCost();
    }

    public void ComputeCost()
    {
      double finalCost = 0;
      foreach(string top in myToppings) {
        finalCost = finalCost + Convert.ToDouble(Toppings[top]);
      }
      Console.WriteLine(myToppings.Count);
      Cost = baseCost + finalCost;
    }
  }
}
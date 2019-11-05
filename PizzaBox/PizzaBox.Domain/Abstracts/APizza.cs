using System;
using System.Collections;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Abstracts
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
        if (value == "hand-tossed") {
          crust = "hand-tossed";
        } else if (value == "pan") {
          crust = "pan";
        } else if (value == "thin") {
          crust = "thin";
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

    public bool CanAddTopping()
    {
      return myToppings.Count < 5;
    }
    public void ShowToppings()
    {
      Console.WriteLine($"Your pizza currently have {Convert.ToString(myToppings.Count)} toppings.");
      if (myToppings.Count != 0) {
        string toppingsString = "";
        foreach(string top in myToppings)
        {
          toppingsString = toppingsString + " " + top;
        }
        Console.WriteLine(toppingsString);
      }
    }
    public void AddTopping(string topping)
    {
      if (myToppings.Count < 5) {
        myToppings.Add(topping);
      } else {
        Console.WriteLine("You can only have a maximum of 5 toppings per pizza.");
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
    public override string ToString()
    {
      string stringTopping = "";

      foreach (string top in myToppings)
      {
        stringTopping = stringTopping + " " + top;
      }
      return Size + " " + Crust + " " + stringTopping;
    }
  }
}
using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {
    private const int V = 1;

    public void BuildPizza()
    {
      Console.WriteLine("Please select the size of your pizza:");
      Console.WriteLine("[0] Small ($3.00)\n[1] Medium ($4.00)\n[2] Large ($5.00)");
      SelectSize();
      Console.WriteLine("Please select the type of crust for your pizza:");
      Console.WriteLine("[0] Hand Tossed\n[1] Pan\n[2] Thin");
      SelectCrust();
      SelectTopping();
    }

    private void SelectSize()
    {
      int choice;
      string input = Console.ReadLine();
      if (int.TryParse(input, out choice))
      {
        if (choice == 0)
        {
          this.Size = "small";
        }
        else if (choice == 1)
        {
          this.Size = "medium";
        }
        else if (choice == 2)
        {
          this.Size = "large";
        }
        else
        {
          Console.WriteLine("Please try again");
          SelectSize();
        }
      }
      else
      {
        Console.WriteLine("Please try again");
        SelectSize();
      }
    }
    private void SelectCrust()
    {
      int choice;
      string input = Console.ReadLine();
      if (int.TryParse(input, out choice))
      {
        if (choice == 0)
        {
          this.Crust = "hand-tossed";
        }
        else if (choice == 1)
        {
          this.Crust = "pan";
        }
        else if (choice == 2)
        {
          this.Crust = "thin";
        }
        else
        {
          Console.WriteLine("Please try again");
          SelectCrust();
        }
      }
      else
      {
        Console.WriteLine("Please try again");
        SelectCrust();
      }
    }

    public void AddOfAddTop(string top) {
      AddTopping(top);
      if (CanAddTopping()) {
        SelectTopping();
      } else {
        Console.WriteLine("You have reach the maximum number of toppings.");
      }
    }
    public void SelectTopping()
    {
      if (CanAddTopping()) {
        Console.WriteLine("Would you like to add topping to your pizza? You are allowed to have five.");
        ShowToppings();
        Console.WriteLine("[0] Pepperoni (+$1.50)\n[1] Bacon (+$1.50)\n[2] Sausage (+$1.50)\n[3] Black Olives (+$0.50)\n[4] Green Peppers (+$0.50)\n[5] Mushrooms (+$0.50)\n[6] Done");
        int selection;
        string inputString = Console.ReadLine();
        if (int.TryParse(inputString, out selection)) {
          switch(selection) {
            case 0:
              AddOfAddTop("pepperoni");
              break;
            case 1:
              AddOfAddTop("bacon");
              break;
            case 2:
              AddOfAddTop("sausage");
              break;
            case 3:
              AddOfAddTop("black_olives");
              break;
            case 4:
              AddOfAddTop("green_peppers");
              break;
            case 5:
              AddOfAddTop("mushrooms");
              break;
            case 6:
              break;
            default:
              Console.WriteLine("Please Try Again");
              SelectTopping();
              break;
          }
        } else {
          Console.WriteLine("Please Try Again");
          SelectTopping();
        }
      } else {
        Console.Write("You have reach the maximum number of toppings.");
      }

    }



  }
}
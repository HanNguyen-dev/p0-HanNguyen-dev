using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Factories;
using static PizzaBox.Domain.Delegates.OrderRepoDelegate;

namespace PizzaBox.Domain.Models
{
  public class Order : AOrder
  {
    public User CurrentUser { get; set; }
    public Store CurrentStore { get; set; }
    public List<APizza> MyPizzas { get; set; }
    public List<Transaction> theOrders;
    public double TotalCost { get; set; }

    public ReadOrderNumberDelegate readOrderNumber;
    public WriteOrderNumberDelegate writeOrderNumber;
    public WriteDelegate writeData;
    private PizzaFactory pizzaFactory;

    public Order(User user, Store store, List<Transaction> orderRepo, ReadOrderNumberDelegate readOrderNumber, WriteOrderNumberDelegate writeOrderNumber, WriteDelegate writeData)
    {
      this.theOrders = orderRepo;
      this.CurrentUser = user;
      this.CurrentStore = store;
      MyPizzas = new List<APizza>();
      this.TotalCost = 0;

      this.readOrderNumber = readOrderNumber;
      this.writeOrderNumber = writeOrderNumber;
      this.writeData = writeData;

      pizzaFactory = new PizzaFactory();
    }

    public bool StartOrder()
    {
      Console.WriteLine("\nMay I take your order, please.");
      BuildOrder();

      return true;
    }
    public bool BuildOrder() {
      Console.WriteLine("[0] Order Pizza\n[1] Confirm order and Pay\n[2] Logout/Cancel order");

      int select;
      string input = Console.ReadLine();
      if (int.TryParse(input, out select)) {
        if (select == 0) {
          APizza thePizza = AddPizza();
          if (thePizza == null) {
            return true;
          }
          if (this.TotalCost + thePizza.Cost > 250)
          {
            Console.WriteLine("Your order can't exceed $250. Please try again.");
            BuildOrder();
          } else {
            this.TotalCost += thePizza.Cost;
            MyPizzas.Add(thePizza);
            BuildOrder();
          }
        } else if (select == 1) {
          ConfirmOrder();
        } else if (select != 2) {
          Console.WriteLine("Please try again");
          BuildOrder();
        }
      } else {
        Console.WriteLine("Please try again");
        BuildOrder();
      }

      return true;
    }

    public APizza AddPizza()
    {
      // default pizza
      // custom pizza
      APizza newPizza = null;
      Console.WriteLine("Deal - Large Pepperoni, Green Pepper for only $6.99 + $0.01\n");
      Console.WriteLine("[0] Large Hand Tossed Pepperoni, Green Pepper\n[1] Build your own.\n[2] Cancel Order.");
      int select;
      string inputStr = Console.ReadLine();
      if (int.TryParse(inputStr, out select)) {
        if (select == 0) {
          newPizza = AddDefaultPizza();
        } else if (select == 1) {
          newPizza = AddCustomPizza();
        } else if (select != 2) {
          Console.WriteLine("Please try again.\n");
          newPizza = AddPizza();
        }
      } else {
        Console.WriteLine("Please try again.\n");
        newPizza = AddPizza();
      }
      return newPizza;
    }

    public APizza AddDefaultPizza() {
      // DefaultPizza one = new DefaultPizza();
      APizza one = pizzaFactory.Create<DefaultPizza>();

      return one;
    }

    public CustomPizza AddCustomPizza() {
      // CustomPizza thePizza = new CustomPizza();
      APizza thePizzaProduct = pizzaFactory.Create<CustomPizza>();
      CustomPizza thePizza = (CustomPizza) thePizzaProduct;

      thePizza.BuildPizza();
      return thePizza;
    }
    public void ConfirmOrder() {
      // int orderNum = OrderRepository.ReadOrderNum() + 1;
      int orderNum = readOrderNumber() + 1;

      int indexPizza = 1;
      List<string> pizzas = new List<string>();
      Console.WriteLine();
      foreach(APizza pizza in MyPizzas) {
        Console.Write($"{indexPizza}. ");
        Console.Write("${0:N2}\t", pizza.Cost);
        Console.WriteLine(pizza);
        pizzas.Add(pizza.ToString());
        indexPizza++;
      }
      Console.WriteLine("Total Cost: ${0:N2}", this.TotalCost);
      Console.WriteLine("Your pizza(s) will be ready in 15-20 minutes.\n");

      Transaction trans1 = new Transaction{orderNum=orderNum, user=CurrentUser.username, storeID=CurrentStore.MyStore, pizzas=pizzas, cost=this.TotalCost};
      theOrders.Add(trans1);
      // OrderRepository.WriteData(theOrders);
      // OrderRepository.StoreOrderNum(orderNum);

      writeData(theOrders);
      writeOrderNumber(orderNum);

      // Update User Time Stamp
      CurrentUser.CompleteOrder();
    }
    public void CancelOrder()
    {
    }

    public List<Transaction> GetOrders() {
      return theOrders;
    }
  }
}
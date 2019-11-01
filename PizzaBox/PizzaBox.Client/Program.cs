using System;
using PizzaBox.Domain.Models;

// testing
using PizzaBox.Storing.Repositories;
using System.Collections;




namespace PizzaBox.Client
{

  internal class Program
  {
    public static void SelectStore(){
      Store store = new Store();
      Console.WriteLine("Please select from the following stores:");
      store.PrintStores();
    }
    private static void Main(string[] args)
    {
      bool option = true;
      int inputValue;

      Console.WriteLine("Welcome to PizzaBox!!");

      while (option)
      {
        Console.WriteLine("Select the following Options");
        Console.WriteLine("[0] To Login\n[1] To Create an Account\n[2] To Quit");
        inputValue = Convert.ToInt32(Console.ReadLine());
        User currentUser = new User();

        if (inputValue == 0)
        {
          // User Login
          if (currentUser.Login())
          {
            SelectStore();// fixed later
          }

        } else if (inputValue == 1)
        {
          // User create an account
          if (currentUser.CreateAccount()) {
            SelectStore(); // fixed later
            Account name;
            
          }
        } else if (inputValue == 2) {
          option = false;
        }
      }



      DefaultPizza pizza = new DefaultPizza();
      Console.WriteLine(pizza.Crust);
      Console.WriteLine(pizza.Cost);
      Hashtable one = UserRepository.readData();
      // one.Add("bob", "howaik");
      // foreach(string username in one.Keys)
      // {
      //   Console.WriteLine($"{username} {one[username]}");
      // }
      // UserRepository.writeData(one);

      Hashtable two = OrderRepository.readData();
    }
  }
}

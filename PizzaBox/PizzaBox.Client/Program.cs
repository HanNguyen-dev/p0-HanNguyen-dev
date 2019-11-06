using System;
using PizzaBox.Domain.Models;

// testing
using PizzaBox.Storing.Repositories;
using System.Collections;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      // Loading data from repository

      // UserRepository.Create();
      // OrderRepository.Create();

      Hashtable usersData = UserRepository.readData();
      string[] storesData = StoreRepository.stores;
      List<Transaction> ordersData = OrderRepository.ReadData();


      bool option = true;
      int inputValue;

      Console.WriteLine("Welcome to PizzaBox!!\n");

      while (option)
      {
        Console.WriteLine("Select the following Options");
        Console.WriteLine("[0] To Login\n[1] To Create an Account\n[2] To Quit");

        string inputString = Console.ReadLine();
        if (!int.TryParse(inputString, out inputValue)) {
          System.Console.WriteLine("Please try again.\n");
          inputValue = 4;
        }

        UserClient currentUser = new UserClient(usersData);//, UserRepository.writeData);
        Store currentStore = new Store(storesData);
        OrderClient currentOrder = new OrderClient(currentUser, currentStore, ordersData);//, OrderRepository.ReadOrderNum, OrderRepository.StoreOrderNum, OrderRepository.WriteData);

        /**************
         * User Login *
         **************/
        if (inputValue == 0) {
          if (currentUser.Login()) {
          // if (Login(currentUser)) {
            currentUser.ViewOrderHistory(currentOrder.GetOrders());
            if (currentUser.CanChangeStore()) {
              currentStore.SelectStore();
              currentUser.ChangeStore(currentStore.MyStore);

              currentOrder.StartOrder();
            } else {
              currentStore.MyStore = currentUser.LastStore;
              Console.WriteLine("Your current store is");
              Console.WriteLine(currentStore.MyAddress);

              currentOrder.StartOrder();
            }
          }
        /***************
         * Create User *
         ***************/
        } else if (inputValue == 1) {
          if (currentUser.CreateAccount()) {
            currentStore.SelectStore();
            currentUser.ChangeStore(currentStore.MyStore);

            currentOrder.StartOrder();
          }
        }
        else if (inputValue == 2)
        {
          option = false;
        }
      }
    }

    // public static bool Login(User user)
    // {
    //   Console.Write("Enter your username: ");
    //   string inputUser = Console.ReadLine();
    //   Console.Write("Enter your password: ");
    //   string inputPass = Console.ReadLine();
    //   Console.WriteLine();

    //   Account currentAccount = UserRepository.FindByUsername(inputUser);
    //   if (currentAccount != null)
    //   {
    //     // Account currentAccount = (Account) userAccounts[inputUser];
    //     if (inputPass == currentAccount.password)
    //     {
    //       user.theAccount = currentAccount;
    //       return true;
    //     }
    //   }
    //   Console.WriteLine("Invalid username or password.  Please try again");
    //   return false;
    // }

    // public static bool CreateAccount(User user, Hashtable userAccounts)
    // {
    //   Console.Write("Create a username: ");
    //   string newUser = Console.ReadLine();

    //   Account currentAccount = UserRepository.FindByUsername(newUser);

    //   if (currentAccount != null)
    //   {
    //     Console.WriteLine("Username already has been taken.\nPlease try again.\n");
    //     return false;
    //   }
    //   Console.Write("Create a password: ");
    //   string newPassword = Console.ReadLine();

    //   Account newAccount = new Account{username=newUser, password=newPassword, storeID=0, orderTime=new DateTime(2019, 1, 1)};
    //   user.theAccount = newAccount;
    //   userAccounts.Add(newUser, newAccount);
    //   // WriteData(userAccounts);
    //   UserRepository.writeData(userAccounts);

    //   return true;
    // }


  }
}

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

      UserRepository.Create();
      OrderRepository.Create();

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

        User currentUser = new User(usersData, UserRepository.writeData);
        Store currentStore = new Store(storesData);
        Order currentOrder = new Order(currentUser, currentStore, ordersData, OrderRepository.ReadOrderNum, OrderRepository.StoreOrderNum, OrderRepository.WriteData);

        /**************
         * User Login *
         **************/
        if (inputValue == 0) {
          if (currentUser.Login()) {
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
  }
}

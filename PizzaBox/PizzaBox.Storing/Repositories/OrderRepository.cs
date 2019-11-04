using System;
using System.IO;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Newtonsoft.Json;


namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    // private const string FILE = "PizzaBox.Storing/Repositories/orders.json";
    // private const string FILE_ORDERNUM = "PizzaBox.Storing/Repositories/order_number.txt";

    private static int order_number;
    private static List<Transaction> transactions = new List<Transaction>();

    public static void Create()
    {
      order_number = 4;

      // transactions = new List<Transaction>();

      transactions.Add(new Transaction{orderNum=1, user="cool", storeID=3, pizzas=new List<string>(){"small pan mushrooms"}, cost=3.5});
      transactions.Add(new Transaction{orderNum=2, user="cool", storeID=2, pizzas=new List<string>(){"large pepperoni green_peppers","large thin black_olives mushrooms"}, cost=13.0});
      transactions.Add(new Transaction{orderNum=3, user="hot", storeID=1, pizzas=new List<string>(){"large   pepperoni green_peppers","large hand-tossed  black_olives 	green_peppers mushrooms"}, cost=13.5});
      transactions.Add(new Transaction{orderNum=4, user="bob", storeID=1, pizzas=new List<string>(){"small pan onions"}, cost=3.5});
    }
    public static int ReadOrderNum()
    {
      return order_number;
    }

    public static void StoreOrderNum(int nextOrderNumber)
    {
      order_number = nextOrderNumber;
    }

    public static List<Transaction> ReadData()
    {
      return transactions;
    }

    public static void WriteData(List<Transaction> orderData)
    {
      transactions = orderData;
    }

  }
}
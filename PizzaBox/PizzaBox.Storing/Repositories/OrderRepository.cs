using System;
using System.IO;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Connectors;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private const string FILE_ORDERNUM = "PizzaBox.Storing/Repositories/order_number.txt";

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
      StreamReader reader = new StreamReader(FILE_ORDERNUM);
      string fileInput = reader.ReadToEnd();
      if (int.TryParse(fileInput, out order_number))
      {
        return order_number;
      }
      return order_number;
    }

    public static void StoreOrderNum(int nextOrderNumber)
    {
      StreamWriter writer = new StreamWriter(FILE_ORDERNUM);
      string intString = Convert.ToString(nextOrderNumber);
      writer.Write(intString);
      writer.Close();

      // order_number = nextOrderNumber;
    }

    public static List<Transaction> ReadData()
    {
      transactions = OrderFileConnector.ReadXml();
      return transactions;
    }

    public static void WriteData(List<Transaction> orderData)
    {
      OrderFileConnector.WriteXml(orderData);
      // transactions = orderData;
    }

  }
}
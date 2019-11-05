using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace  PizzaBox.Storing.Connectors
{

  public class OrderFileConnector
  {
    private const string FILE = "PizzaBox.Storing/Repositories/orders.xml";

    public static List<Transaction> ReadXml()
    {
      var xml = new XmlSerializer(typeof(List<Transaction>));
      StreamReader reader = new StreamReader(FILE);
      var data = xml.Deserialize(reader) as List<Transaction>;

      // List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(reader.ReadToEnd());
      return data;
    }

    public static void WriteXml(List<Transaction> data)
    {
      var xml = new XmlSerializer(typeof(List<Transaction>));
      StreamWriter writer = new StreamWriter(FILE);
      xml.Serialize(writer, data);
    }

  }
}
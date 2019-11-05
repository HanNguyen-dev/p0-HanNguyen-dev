using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace  PizzaBox.Storing.Connectors
{

  public class UserFileConnector
  {
    private const string FILE = "PizzaBox.Storing/Repositories/users.xml";

    public static List<Account> ReadXml()
    {
      var xml = new XmlSerializer(typeof(List<Account>));
      StreamReader reader = new StreamReader(FILE);
      var data = xml.Deserialize(reader) as List<Account>;

      // List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(reader.ReadToEnd());
      return data;
    }

    public static void WriteXml(List<Account> accounts)
    {
      var xml = new XmlSerializer(typeof(List<Account>));
      StreamWriter writer = new StreamWriter(FILE);
      xml.Serialize(writer, accounts);
    }

  }
}
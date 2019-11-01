using System;
using System.Collections;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models
{
  public class User : AUser
  {
    private Hashtable users;
    public string username { get; private set; }
    public string password { get; private set; }
    public int LastStore { get; set; }
    public DateTime LastOrderTime { get; set; }
    public User()
    {
      this.users = UserRepository.readData();
    }

    public bool Login()
    {
      Console.Write("Enter your username: ");
      string inputUser = Console.ReadLine();
      Console.Write("Enter your password: ");
      string inputPass = Console.ReadLine();
      Console.WriteLine();

      if (users.ContainsKey(inputUser) && inputPass == Convert.ToString(users[inputUser]))
      {
        this.username = username;
        this.password = password;
        return true;
      }
      Console.WriteLine("Invalid username or password.  Please try again");
      return false;
    }

    public bool CreateAccount()
    {
      Console.Write("Create a username: ");
      string newUser = Console.ReadLine();

      if (users.ContainsKey(newUser))
      {
        Console.WriteLine("Username already has been taken.\nPlease try again.");
        return false;
      }
      Console.Write("Create a password: ");
      string newPassword = Console.ReadLine();

      this.username = newUser;
      this.password = newPassword;
      users.Add(newUser, newPassword);
      UserRepository.writeData(users);
      // what to do with
      Console.WriteLine("Please login with your new account");
      return true;
    }

    public bool CanChangeStore()
    {
      TimeSpan elapsedTime = new TimeSpan(DateTime.Now.Ticks - LastOrderTime.Ticks);

      if (elapsedTime.TotalHours > 24 ) {
        return true;
      }
      return false;
    }
    public void ChangeLocation(int storeNumber)
    {
      LastStore = storeNumber;
    }
    public bool CompleteOrder()
    {
      LastOrderTime = DateTime.Now;
      return true;
    }
  }
}
using System;
using System.Collections;
using PizzaBox.Domain.Abstracts;
using static PizzaBox.Domain.Delegates.UserRepoDelegate;

namespace PizzaBox.Domain.Models
{
  public class User : AUser
  {
    private Hashtable userAccounts;
    public WriteDelegate WriteData;

    public User(Hashtable userRepo, WriteDelegate WriteData)
    {
      this.userAccounts = userRepo;
      this.WriteData = WriteData;
    }

    public bool Login()
    {
      Console.Write("Enter your username: ");
      string inputUser = Console.ReadLine();
      Console.Write("Enter your password: ");
      string inputPass = Console.ReadLine();
      Console.WriteLine();

      if (userAccounts.ContainsKey(inputUser))
      {
        Account currentAccount = (Account) userAccounts[inputUser];
        if (inputPass == currentAccount.password)
        {
          theAccount = currentAccount;
          return true;
        }
      }
      Console.WriteLine("Invalid username or password.  Please try again");
      return false;
    }

    public bool CreateAccount()
    {
      Console.Write("Create a username: ");
      string newUser = Console.ReadLine();

      if (userAccounts.ContainsKey(newUser))
      {
        Console.WriteLine("Username already has been taken.\nPlease try again.\n");
        return false;
      }
      Console.Write("Create a password: ");
      string newPassword = Console.ReadLine();

      Account newAccount = new Account{username=newUser, password=newPassword, storeID=0, orderTime=new DateTime(2019, 1, 1)};
      theAccount = newAccount;
      userAccounts.Add(newUser, newAccount);
      WriteData(userAccounts);
      // UserRepository.writeData(userAccounts);

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
    public void ChangeStore(int storeNumber)
    {
      theAccount.storeID = storeNumber;
    }
    public void CompleteOrder()
    {
      LastOrderTime = DateTime.Now;
      userAccounts[this.username] = this.theAccount;

      WriteData(userAccounts);
      // return true;
    }
  }
}
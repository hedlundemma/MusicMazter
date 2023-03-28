using System;
namespace MusicMazter;

public class User
{
    public string Name { get; set; }
    public int Balance { get; set; }

    public List<string> boughtItems;

    public User(string name, int balance)
    {
        Name = name;
        Balance = balance;
        boughtItems = new List<string>();
    }

    public int showUserBalance()
    {
        return this.Balance;
    }

    public int updateUserBalance(int price)
    {
        return this.Balance -= price;
    }
}

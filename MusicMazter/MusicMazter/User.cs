using System;
namespace MusicMazter;

public class User
{

    public string Name { get; set; }
    public double Balance { get; set; }

    public User(string name, double balance)
    {
        Name = name;
        Balance = balance;

    }

    public double showUserBalance()
    {
        return this.Balance;

    }

    public void updateUserBalance(int price) {

        this.Balance -= price;

    }
}

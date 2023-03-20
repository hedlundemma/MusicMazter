using System;
namespace MusicMazter;

public class Bank
{
    public string Name { get; set; }
    public double Balance { get; set; }

    public Bank(string name, double balance)
    {

        Name = name;
        Balance = balance;
    }
}


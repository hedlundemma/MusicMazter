using MusicMazter;

var vendingMachine = new VendingMachine();

Console.WriteLine("Hello dear customer and welcome to MusicMazters wonderful vending machine!");
Console.WriteLine("Please put in your name so you can get to shopping:");

string answer = null;
while (answer == null || answer == "")
{
    if (answer == "")
    {
        Console.WriteLine("That's not a name silly, please type it again.");
    }
    answer = Console.ReadLine();
}

var shopper = new User(answer, 200);

vendingMachine.StartVendingMachine(shopper);




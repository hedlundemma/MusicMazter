using System;
using System.Reflection;
using MusicMazter;

namespace MusicMazter
{
    public class VendingMachine
    {

        public List<Inventory> GetInventories { get; } = new List<Inventory>
        {
            new Inventory ("Guitar", 40, 3),
            new Inventory ("Drums", 50, 1),
            new Inventory ("Flute", 20, 10),
            new Inventory ("Base", 49, 3),
            new Inventory ("Maracas", 10, 4),
            new Inventory ("Tamburin", 25, 6)

        };

        public List<string> Menu { get; } = new List<string>
        {
            "purchase instrument",
            "check balance",
            "inventory"

        };

       

        public void StartVendingMachine(User shopper)

        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Welcome {shopper.Name}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("____________MENU__________");
            foreach (var MenuOptions in Menu)
            {
                Console.WriteLine(MenuOptions);
            }
            Console.WriteLine("___________________________");

            Console.ForegroundColor = ConsoleColor.Green;

            string input;


            do
            {
                input = ShowMenu();


                if (input == "purchase instrument")
                {
                    // lägg  till vad som händer med en funktion
                }
                else if (input == "check balance")
                {
                    ShowBalance(shopper);
                }
                else if (input == "inventory")

                {
                    DisplayInventory();


                }
            }
            while (input != null);
            
        }

        public string ShowMenu()
        {

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Choose a option from the menu above");
                Console.ResetColor();

                var input = Console.ReadLine();

                if (input != null)
                {
                    
                    return input;
                }
            }
        }

        // visa hur mycket pengar personen har på sitt konto 
        public void ShowBalance(User shopper)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{shopper.Name} currently have: ${shopper.showUserBalance()}");
            Console.WriteLine("________________________________________");
            Console.ResetColor();
        }


        // visa inventory 
        public void DisplayInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Heres our instruments thats currently for sale:");
            Console.ResetColor();
            foreach (var instrument in GetInventories)
            {
                if (instrument.Quantity != 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{instrument.Name}, quantity: {instrument.Quantity}, cost: {instrument.Price}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("__________________________________");



        }
    }
}


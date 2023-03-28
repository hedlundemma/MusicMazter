using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
            new Inventory ("Bass", 49, 3),
            new Inventory ("Maracas", 10, 4),
            new Inventory ("Tamburine", 25, 6)

        };

        public List<string> Menu { get; } = new List<string>
        {
            "purchase instrument",
            "check balance",
            "inventory",
            "my purchases",
            "exit"
        };


        public void StartVendingMachine(User shopper)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\nWelcome {shopper.Name}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\n____________MENU____________\n");
            foreach (var MenuOptions in Menu)
            {
                Console.WriteLine(MenuOptions);
            }
            Console.WriteLine("____________________________");

            Console.ForegroundColor = ConsoleColor.Green;

            string input;


            do
            {
                input = ShowMenu();

                if (input == "purchase instrument")
                {
                    MakePurchase(shopper);
                    ShowBalance(shopper);
                }
                else if (input == "check balance")
                {
                    ShowBalance(shopper);
                }
                else if (input == "inventory")
                {
                    DisplayInventory();
                }
                else if (input == "my purchases")
                {
                    ViewShopperInventory(shopper);
                }
                else if (input == "exit")
                {
                    break;
                }
            }
            while (input != null);
        }

        // visa menyn för kunden
        public string ShowMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Choose an option from the menu above");
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

        // anpassa inventory när personen köper en vara
        public void AdjustInventory(string choice)
        {
            foreach (var instrument in GetInventories)
            {
                int newInventory = instrument.Quantity - 1;
                if (choice == instrument.Name)
                {
                    instrument.Quantity = newInventory;
                }
            }
        }

        // visa inventory 
        public void DisplayInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Here's our instruments that's currently for sale:");
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
            Console.WriteLine("________________________________________");
        }

        // visa inventory för det personen har köpt
        public void ViewShopperInventory(User shopper)
        {
            if (shopper.boughtItems.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You haven't bought anything from us yet.");

                Console.ResetColor();

            }
            foreach (var instrument in shopper.boughtItems)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
                Console.WriteLine(instrument);
                Console.WriteLine();
            }
        }


        // göra ett köp i vending-machinen
        public void MakePurchase(User shopper)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            DisplayInventory();
            Console.WriteLine("\nPlease write the name of the instrument you would like to buy.");

            var choice = Console.ReadLine().ToLower();

            Inventory choosenInstrument = null;
            foreach (var instrument in GetInventories)
            {
                if (instrument.Name.ToLower() == choice)
                {
                    choosenInstrument = instrument;
                }

                if (choosenInstrument != null)
                {

                    if (choosenInstrument.Price >= shopper.Balance)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry {shopper.Name}, you don't have enough money.");
                    }

                    if (choosenInstrument.Quantity != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"You've selected {choice} for {choosenInstrument.Price} dollars.");
                        Console.WriteLine("________________________________________");
                        Console.ResetColor();

                        shopper.updateUserBalance(choosenInstrument.Price);
                        shopper.boughtItems.Add(choosenInstrument.Name);

                        AdjustInventory(choice);

                        return;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oppsie, we don't have {choice}");
        }
    }
}
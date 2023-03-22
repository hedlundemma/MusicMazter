using System;
using System.Reflection;
using MusicMazter;

namespace MusicMazter
{
    public class VendingMachine
    {


        public List<string> Menu { get; } = new List<string>
        {
            "purchase instrument",
            "check balance",
            "inventory",

        };

        public List<Inventory> GetInventories { get; } = new List<Inventory>
        {
            new Inventory ("Guitar", 40, 3),
            new Inventory ("Drums", 50, 1),
            new Inventory ("Flute", 20, 10),
            new Inventory ("Base", 49, 3),
            new Inventory ("Maracas", 10, 4),
            new Inventory ("Tamburin", 25, 6)

        };

        public void StartVendingMachine(User shopper)

        {

            Console.WriteLine($"Welcome {shopper.Name}");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("____________MENU__________");
            foreach (var MenuOptions in Menu)
            {
                Console.WriteLine(MenuOptions);
            }
            Console.WriteLine("___________________________");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Chose an option from the menu to get started");
            var input = Console.ReadLine();




            if (input == "purchase instrument")
            {
                // lägg  till vad som händer med en funktion
            }
            else if (input == "check balance")
            {
                // lägg till vad som händer med en funktion
            }
            else if (input == "inventory")
            {
                //lägg till vad som händer med en funktion
            }










        }

    }
}


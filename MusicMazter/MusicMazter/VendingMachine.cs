using System;
using MusicMazter;

namespace MusicMazter
{
    public class VendingMachine
    {


        public List<Inventory> Inventory { get; set; }
        public Bank Bank { get; set; }

        public VendingMachine(List<Inventory> inventory, Bank bank)
        {
            Inventory = inventory;
            Bank = bank;

        }


    }
}


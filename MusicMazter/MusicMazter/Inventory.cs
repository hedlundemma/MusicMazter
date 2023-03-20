using System;
namespace MusicMazter
{
    public class Inventory
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Inventory(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

    }


}

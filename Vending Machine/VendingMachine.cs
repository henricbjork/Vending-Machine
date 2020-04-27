using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;

namespace Vending_Machine
{ 
    public class VendingMachine
    {
        private readonly List<Item> _machineItems = new List<Item>
        {
            new Item("Chocolate", 20),
            new Item("Candy", 10),
            new Item("Soda", 15),
        };

        public void ListItems()
        {
            if (_machineItems.Count == 0)
            {
                Console.WriteLine("This machine is empty");
                return;
            }

            var itemNumber = 0;

            foreach (var item in _machineItems)
            {
                itemNumber++;
                Console.WriteLine($"{itemNumber}. {item.Name} - {item.Price}kr");
            }
        }

        public Item BuyItem(string input, int money)
        {
            int.TryParse(input, out int ui);
            ui -= 1; // This is so that the items list number doesn't conflict with the items index number.
            
            var item = _machineItems[ui];

            for (var i = 0; i < _machineItems.Count; i++)
            {
                if (item.Name != _machineItems[i].Name || money < item.Price) continue;
                Console.WriteLine($"You purchased {item.Name} for {item.Price}kr");
                return item;
            }

            Console.WriteLine("An error occured. Please check your balance or make sure that the item exists.");
            return null;
        }
    }
}

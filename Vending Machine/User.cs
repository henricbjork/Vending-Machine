using System;
using System.Collections.Generic;

namespace Vending_Machine
{
    public class User
    {
        public int UserBalance { get; private set; }
        private readonly List<string> _inventory;

        public User()
        {
            _inventory = new List<string>();
        }

        public void AddUserBalance(int amount)
        {
            UserBalance += amount;
        }

        public void WithdrawUserBalance(int amount)
        {
            UserBalance -= amount;
        }

        public void AddItemToInventory(string item)
        {
            if (item == null)
            {
                return;
            }
            
            _inventory.Add(item);
        }
        
        public void ListInventoryItems()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty");
                return;
            }

            var itemNumber = 0;

            Console.WriteLine("Inventory:");
            
            foreach (var item in _inventory)
            {
                itemNumber++;
                Console.WriteLine($"{itemNumber}. {item}");
            }
        }
    }
}
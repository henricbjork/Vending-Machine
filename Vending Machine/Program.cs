using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var myBank = new Bank();
            var vendingMachine = new VendingMachine();

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Check your balance");
                Console.WriteLine("2. Withdraw money");
                Console.WriteLine("3. List the items in your inventory");
                Console.WriteLine("4. Buy something from the vending machine");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine($"Your current balance is {user.UserBalance}kr");
                }

                if (choice == "2")
                {
                    Console.WriteLine("How much would you like to withdraw?");
                    var givenAmount = Console.ReadLine();
                    int.TryParse(givenAmount, out int amount);
                    user.AddUserBalance(myBank.Withdraw(amount));
                }

                if (choice == "3")
                {
                    try
                    {
                        user.ListInventoryItems();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (choice == "4")
                {
                    Console.WriteLine("What would you like to buy?");
                    vendingMachine.ListItems();
                    var input = Console.ReadLine();
                    
                        var item = vendingMachine.BuyItem(input, user.UserBalance);
                        
                        if (item == null) continue;
                        user.AddItemToInventory(item.Name);
                        user.WithdrawUserBalance(item.Price);
                }
            }
        }
    }
}
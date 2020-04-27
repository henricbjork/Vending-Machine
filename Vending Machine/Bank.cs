using System;

namespace Vending_Machine
{
    public class Bank
    {
        private int _balance = 300;

        public int Withdraw(int amount)
       {
           if (_balance < amount)
           {
               Console.WriteLine("There is not enough money on your account.");
               return 0;
           }

           _balance -= amount;
           return amount;
       }
    }
}
using BancoExce.Entities;
using BancoExce.Entities.Exceptions;
using System;
using System.Globalization;

namespace BancoExce
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter account data: ");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial balance: ");
            double initialDeposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Account account = new Account(number, holder, initialDeposit, withdrawLimit);

            Console.WriteLine();
            Console.Write("Enter amount for withdraw: ");
            try
            {
                account.Withdraw(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                Console.WriteLine(account);
            }
            catch(DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}

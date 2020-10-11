using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class FeedMoneyMenu : IMenu
    {
        VendingMachine Vendomatic { get; }
        AuditLogger Auditor { get; }
        
        public FeedMoneyMenu(VendingMachine vendomatic, AuditLogger auditor)
        {
            Vendomatic = vendomatic;
            Auditor = auditor;
        }
        
        public bool GoTo()
        {
            bool continueToFeed = true;
            do
            {
                string[] possibleBills = new string[] { "1", "5", "10", "20", "cancel" };
                bool isBill;
                string moneyFed;
                do
                {
                    Console.Write("Please enter the amount of money [1, 5, 10, 20, or \"cancel\"]): ");
                    moneyFed = Console.ReadLine().ToLower();
                    
                    
                    isBill = possibleBills.Contains(moneyFed);
                    if (!isBill)
                    {
                        Console.WriteLine("Not a valid amount.");
                    }
                }
                while (!isBill);

                if (moneyFed != "cancel")
                {
                    Vendomatic.FeedMoney(decimal.Parse(moneyFed));
                    Console.WriteLine($"Money added: {moneyFed}   Current balance: {Vendomatic.Balance}");
                }

                Console.Write("Continue feeding money? 1=Yes / 2=No : ");
                Char feedMoneyYorN = Console.ReadKey().KeyChar;
                Console.WriteLine();
                bool canContinue = false;
                while (!canContinue)
                {
                    switch (feedMoneyYorN)
                    {
                        case '1': //yes
                            canContinue = true; continueToFeed = true; break;
                        case '2': //no
                            canContinue = true; continueToFeed = false; break;
                        default:
                            Console.WriteLine("Please try again. Insert more money? 1=Yes / 2=No : ");
                            feedMoneyYorN = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            canContinue = false; break;
                    }
                }
            }
            while (continueToFeed);
            return true;
        }
    }
}

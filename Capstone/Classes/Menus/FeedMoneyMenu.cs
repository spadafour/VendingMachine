using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            while (continueToFeed == true)
            {
                Console.WriteLine("Please enter the amount of money in dollar bills you would like to feed into the vending machine");
                string moneyFedToBeCast = Console.ReadLine();
                try
                {
                    decimal moneyFed = decimal.Parse(moneyFedToBeCast);
                    decimal[] billTest = new decimal[] { 1, 5, 10, 20 };
                    if (!billTest.Contains(moneyFed))
                    {
                        Console.WriteLine("Only 1, 5, 10, and 20 dollar bills can be inserted");
                        Console.WriteLine();
                        break;
                    }

                    Vendomatic.FeedMoney(moneyFed);
                    Auditor.LogMoneyIn(moneyFed, Vendomatic.GetBalance());//rspadafore: added line to audit moneyFed
                    Console.WriteLine($"The vending maching balance is {Vendomatic.Balance}");
                    Console.Write("Type N to stop feeding money to the machine, or any other key to continue feeding money ");
                    Char feedMoneyYorN = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (feedMoneyYorN == 'N' || feedMoneyYorN == 'n')
                    {
                        continueToFeed = false;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong, please try again");
                    continueToFeed = true;

                }
            }
            return true;
        }
    }
}

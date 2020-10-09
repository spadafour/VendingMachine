using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus.SubMenus
{
    public class FinishTransactionMenu
    {
        public static bool GoToFinishTransactionMenu(VendingMachine vendingMachine)
        {
            Console.Write("Are you sure you want to exit? 1=Yes / 2=No: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool isOption = false;
            bool shouldExit = false;
            do
            {
                switch (userSelection)
                {
                    case '1': //Yes
                        Console.WriteLine("Dispensing Change:");
                        Dictionary<string, int> coinPurse = vendingMachine.MakeChange();
                        foreach (string coin in coinPurse.Keys)
                        {
                            Console.WriteLine($"{coin}: {coinPurse[coin]}");
                        }
                        Console.WriteLine("\n" + "Vendo-Matic Balance: " + vendingMachine.GetBalance() + "\n");
                        userSelection = '0'; isOption = true; shouldExit = true; break;
                    case '2': //No
                        Console.WriteLine("Returning to Main Menu");
                        userSelection = '0'; isOption = true; shouldExit = false; break;
                    default:
                        Console.Write("Are you sure you want to exit? 1=Yes / 2=No : ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        isOption = false; break;
                }
            }
            while (!isOption);

            return shouldExit;
        }
    }
}

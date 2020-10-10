using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class FinishTransactionMenu : IMenu
    {
        VendingMachine Vendomatic { get; }

        public FinishTransactionMenu(VendingMachine vendomatic)
        {
            Vendomatic = vendomatic;
        }

        public bool GoTo()
        {
            Console.Write("Finish transaction and dispense change? 1=Yes / 2=No: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool answeredYOrN = false;
            bool shouldExit = false;
            do
            {
                switch (userSelection)
                {
                    case '1': //Yes
                        Console.WriteLine("Dispensing Change:");
                        Dictionary<string, int> coinPurse = Vendomatic.MakeChange();
                        foreach (string coin in coinPurse.Keys)
                        {
                            Console.WriteLine($"{coin}: {coinPurse[coin]}");
                        }
                        Console.WriteLine("\n" + "Vendo-Matic Balance: " + Vendomatic.GetBalance() + "\n");
                        userSelection = '0'; answeredYOrN = true; shouldExit = true; break;
                    case '2': //No
                        Console.WriteLine("Returning to Main Menu");
                        userSelection = '0'; answeredYOrN = true; shouldExit = false; break;
                    default:
                        Console.Write("Finish transaction and dispense change? 1=Yes / 2=No : ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        answeredYOrN = false; break;
                }
            }
            while (!answeredYOrN);

            return shouldExit;
        }
    }
}

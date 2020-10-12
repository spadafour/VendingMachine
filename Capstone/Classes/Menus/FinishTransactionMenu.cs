using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class FinishTransactionMenu : IMenu
    {
        VendingMachine Vendomatic { get; }
        AuditLogger Auditor { get; }

        public FinishTransactionMenu(VendingMachine vendomatic, AuditLogger auditor)
        {
            Vendomatic = vendomatic;
            Auditor = auditor;
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
                        if (Vendomatic.Balance > 0)
                        {
                            Console.WriteLine("Dispensing Change:");
                            Auditor.HoldBalance(Vendomatic.Balance);
                            Dictionary<string, int> coinPurse = Vendomatic.MakeChange();
                            Auditor.LogChangeMade(Vendomatic.Balance);
                            foreach (string coin in coinPurse.Keys)
                            {
                                Console.WriteLine($"{coin}: {coinPurse[coin]}");
                            }
                            Console.WriteLine();
                        }
                        userSelection = '0'; answeredYOrN = true; shouldExit = true; break;
                    case '2': //No
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

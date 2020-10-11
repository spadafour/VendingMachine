using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace Capstone.Classes.Menus
{
    public class PurchaseMenu : IMenu
    {
        public VendingMachine Vendomatic { get; }
        public AuditLogger Auditor { get; }

        public PurchaseMenu(VendingMachine vendomatic, AuditLogger auditor)
        {
            Vendomatic = vendomatic;
            Auditor = auditor;
        }

        public bool GoTo()
        {
            Console.WriteLine("Purchase Menu");
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.Write("Purchase Menu Selection: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine();
            IMenu menu;
            bool shouldReturnToMain = false;
            do
            { 
                switch (userSelection)
                {
                    case '1':
                        userSelection = '0';
                        menu = new FeedMoneyMenu(Vendomatic, Auditor);
                        menu.GoTo();
                        break;
                    case '2':
                        userSelection = '0';
                        menu = new SelectProductMenu(Vendomatic, Auditor);
                        menu.GoTo();
                        break;
                    case '3':
                        userSelection = '0';
                        menu = new FinishTransactionMenu(Vendomatic, Auditor);
                        shouldReturnToMain = menu.GoTo();
                        Auditor.AuditWriter();
                        break;
                    default:
                        Console.WriteLine("Purchase Menu");
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.Write("Purchase Menu Selection: ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        break;
                }
            }
            while (!shouldReturnToMain);

            return true;
        }
    }
}

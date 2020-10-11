using Capstone.Classes.Menus;
using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {
        private VendingMachine Vendomatic { get; set; }
        public AuditLogger Auditor = new AuditLogger();

        public void UIStart()
        {
            Vendomatic = new Stocker().StockVendingMachine();
            GoToMenus();
        }

        public bool GoToMenus()
        {
            Console.WriteLine("Vendo-Matic 800\n");
            IMenu menu = new MainMenu();
            menu.GoTo();
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool keepRunning = true;
            do
            {
                switch (userSelection)
                {
                    case '1': //Access Display Items Menu
                        menu = new DisplayItemsMenu(Vendomatic);
                        menu.GoTo();
                        userSelection = '0'; keepRunning = true; break;
                    case '2': //Access Purchase Menu
                        menu = new PurchaseMenu(Vendomatic, Auditor);
                        menu.GoTo();
                        userSelection = '0'; keepRunning = true; break;
                    case '3': //Access Exit Menu
                        menu = new ExitMenu();
                        keepRunning = menu.GoTo();
                        userSelection = '0'; break;
                    default:
                        menu = new MainMenu();
                        menu.GoTo();
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        keepRunning = true; break;
                }
            }
            while (keepRunning);

            Console.WriteLine("Thank you! Come again!");
            return true;
        }
    }
}


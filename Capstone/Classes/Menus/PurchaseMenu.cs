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
           
            bool isOption = false;
            do
            {
                Console.WriteLine("Purchase Menu");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.Write("Selection: ");
                Char userSelection = Console.ReadKey().KeyChar;
                Console.WriteLine(System.Environment.NewLine);
                //rspadafore: Added this code to get fixed access to other Menus
                IMenu menu;
                switch (userSelection)
                {
                    case '1':
                        menu = new FeedMoneyMenu(Vendomatic, Auditor);
                        menu.GoTo();
                        break;
                    case '2':
                        Console.WriteLine("Please select an item number from the following list of products");
                        Console.WriteLine($"A balance of {Vendomatic.Balance} remains in the vending machine");
                        //rspadafore: Changed how to access Display Items Menu
                        menu = new DisplayItemsMenu(Vendomatic);
                        menu.GoTo();
                        Console.WriteLine("Now input the key of the item you would like to purchase, or press X to return to purchase menu");
                        string itemKey = Console.ReadLine();
                        Vendomatic.VendSelectedItem(itemKey);
                        break;

                    case '3': //Access Finish Transaction Menu
                        //rspadafore: Changed how to access Finish Transaction Menu
                        menu = new FinishTransactionMenu(Vendomatic, Auditor);
                        menu.GoTo();
                        userSelection = '0'; isOption = true; break;
                    default:
                        Console.WriteLine("A number other than 1, 2, or 3, was entered. Please enter a new number");
                        Console.WriteLine("(1) Display Vending Machine Items");
                        Console.WriteLine("(2) Purchase");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.Write("Selection: ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        isOption = false; break;
                }
            }
            while (!isOption);

            return true;
        }
    }
}

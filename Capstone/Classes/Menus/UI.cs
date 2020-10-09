using Capstone.Classes.Menus.SubMenus;
using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class UI
    {
        public static VendingMachine Vendomatic { get; set; }
        public static DisplayItemsMenu DisplayItems { get; set; }
        public PurchaseMenu Purchase { get; set; }
        public FinishTransactionMenu FinishTransaction { get; set; }
        public ExitMenu Exit { get; set; }
        public AuditLogger Auditor = new AuditLogger(); //TODO



        public void UIStart()
        {
            //Instantiate Menus
            DisplayItemsMenu displayItems = new DisplayItemsMenu(); DisplayItems = displayItems;
            PurchaseMenu purchase = new PurchaseMenu(); Purchase = purchase;
            FinishTransactionMenu finishTransaction = new FinishTransactionMenu(); FinishTransaction = finishTransaction;
            ExitMenu exit = new ExitMenu(); Exit = exit;

            //Instantiate Vendomatic and Stocker
            //VendingMachine vendomatic = new VendingMachine();
            Stocker stocker = new Stocker();

            Vendomatic = stocker.StockVendingMachine();

            

            Console.WriteLine("Vendo-Matic 800");
            Console.WriteLine();
            GoToMainMenu();
        }

        public bool GoToMainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.Write("Selection: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool isOption = false;
            do
            {
                switch (userSelection)
                {
                    case '1': //Access Display Items Menu
                        DisplayItems.GoToDisplayItemsMenu();
                        userSelection = '0'; isOption = false; break;
                    case '2': //Access Purchase Menu
                        Purchase.GoToPurchaseMenu();
                        userSelection = '0'; isOption = false; break;
                    case '3': //Access Exit
                        isOption = Exit.GoToExitMenu();
                        userSelection = '0'; break;
                    default:
                        Console.WriteLine("Main Menu");
                        Console.WriteLine("(1) Display Vending Machine Items");
                        Console.WriteLine("(2) Purchase");
                        Console.WriteLine("(3) Exit");
                        Console.Write("Selection: ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        isOption = false; break;
                }
            }
            while (!isOption);

            Console.WriteLine("Thank you! Come again!");
            return true;
        }
    }
}


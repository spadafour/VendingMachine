using Capstone.Classes.Menus.SubMenus;
using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class UI
    {
        public VendingMachine VendingMachine = new VendingMachine();

        public void UIStart()
        {
            Stocker stocker = new Stocker();
            VendingMachine = stocker.GenerateNewVendingMachine();
            Console.WriteLine("Vendo-Matic 800");
            Console.WriteLine();
            GoToMainMenu(VendingMachine);
        }

        public static bool GoToMainMenu(VendingMachine vendingMachine)
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
                        DisplayItemsMenu.GoToDisplayItemsMenu(vendingMachine.GetVendItemInventory());
                        userSelection = '0'; isOption = false; break;
                    case '2': //Access Purchase Menu
                        PurchaseMenu.GoToPurchaseMenu(vendingMachine);
                        userSelection = '0'; isOption = false; break;
                    case '3': //Access Finish Transaction Menu
                        isOption = FinishTransactionMenu.GoToFinishTransactionMenu(vendingMachine);
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

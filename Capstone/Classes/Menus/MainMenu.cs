using Capstone.Classes.Menus.SubMenus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class MainMenu
    {
        public static bool GoToMainMenu(VendingMachine vendingMachine)
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Finish Transaction");
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
                        FinishTransactionMenu.GoToFinishTransactionMenu(vendingMachine.GetBalance());
                        userSelection = '0'; isOption = true; break;
                    default:
                        Console.WriteLine("(1) Display Vending Machine Items");
                        Console.WriteLine("(2) Purchase");
                        Console.WriteLine("(3) Finish Transaction");
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

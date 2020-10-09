using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace Capstone.Classes.Menus.SubMenus
{
    public class PurchaseMenu
    {                //changed return type to for pushing purposes
        public static bool GoToPurchaseMenu(VendingMachine vendingMachine)
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool isOption = false;
            do
            {
                switch (userSelection)
                {
                    case '1': //Feed Money method/case handling -> consider adding most of this shit to FeedMoney method
                        //have to refactor all of this
                        bool continueToFeed = true;
                        while (continueToFeed == true)
                        {
                            Console.WriteLine("Please enter the amount of money in dollars you would like to feed into the vending machine");
                            string moneyFedToBeCast = Console.ReadLine();
                            try
                            {
                                decimal moneyFed = decimal.Parse(moneyFedToBeCast);
                                decimal[] billTest = new decimal[] { 1, 5, 10, 20 };
                                billTest.Contains(moneyFed);
                                vendingMachine.FeedMoney(moneyFed);
                                Console.WriteLine("Type Y to continue feeding money, or N to stop feeding money. Any other input will be registered as N");
                                Char feedMoneyYorN = Console.ReadKey().KeyChar;
                                if (feedMoneyYorN == 'N')
                                {
                                    continueToFeed = false;
                                }
                            }
                            catch (Exception e)
                            {
                                continueToFeed = true;
                            }
                        } break;
                    case '2': //Select Item method/case handling
                        Console.WriteLine("Please select an item number from the following list of products");
                        DisplayItemsMenu.GoToDisplayItemsMenu(vendingMachine.GetVendItemInventory());
                        Console.WriteLine("Now enter the key of the item you would like to purchase");
                        try
                        {
                            string itemKey = Console.ReadLine();
                            vendingMachine.VendSelectedItem(itemKey);
                        }
                        catch
                        {

                        }
                        break;

                    case '3': //Access Finish Transaction Menu
                        FinishTransactionMenu.GoToFinishTransactionMenu(vendingMachine);
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

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
        VendingMachine Vendomatic { get; }

        public PurchaseMenu(VendingMachine vendomatic)
        {
            Vendomatic = vendomatic;
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
                        bool continueToFeed = true;
                        while (continueToFeed == true)
                        {
                            Console.WriteLine("Please enter the amount of money in dollar bills you would like to feed into the vending machine");
                            string moneyFedToBeCast = Console.ReadLine();
                            try
                            {
                                decimal moneyFed = decimal.Parse(moneyFedToBeCast);
                                decimal[] billTest = new decimal[] { 1, 5, 10, 20 };
                                if (!billTest.Contains(moneyFed))
                                    {
                                    Console.WriteLine("Only 1, 5, 10, and 20 dollar bills can be inserted");
                                    Console.WriteLine();
                                    break; }
                               
                                Vendomatic.FeedMoney(moneyFed);
                                Console.WriteLine($"The vending maching balance is {Vendomatic.Balance}");
                                Console.Write("Type N to stop feeding money to the machine, or any other key to continue feeding money ");
                                Char feedMoneyYorN = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                if (feedMoneyYorN == 'N' || feedMoneyYorN == 'n')
                                {
                                    continueToFeed = false;
                                    
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Something went wrong, please try again");
                                continueToFeed = true;
                                
                            }
                        } break;
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
                        menu = new FinishTransactionMenu(Vendomatic);
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

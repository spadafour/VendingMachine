using Capstone.Classes.Menus.SubMenus;
using Capstone.Classes.VendItems;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //Parameters
        private decimal Balance { get; set; } = 0;
        private Dictionary<VendItem, int> VendItemInventory { get; set; } = new Dictionary<VendItem, int>();
        public int VendItemCount { get { return VendItemInventory.Count; } }

        
        //Methods
        public decimal GetBalance()
        {
            return Balance;
        }

        public bool AddItemToInventory(VendItem item, int startingStock)
        {
            VendItemInventory.Add(item, startingStock);
            return true;
        }

        public Dictionary<VendItem, int> GetVendItemInventory()
        {
            return VendItemInventory;
        }

   
        public void FeedMoney(decimal moneyFed) //Adds to VendingMachine Balance, sutbtract from Customer.Balance, Log Money with AuditLogger (maybe return string with new balance??)
        {
            Balance += moneyFed;
        }
        
        public bool VendSelectedItem(string itemKey) //VendItem.Quantity--; balance-=VendItem.Price; ConsoleWriteLine VendItem.Name, .Price, Balance, Message(might need if statements for msg?)
        {/*
                foreach (KeyValuePair<VendItem, int> kvp in VendItemInventory)
                {
                    try
                    {
                        bool secondCheckBool = true;
                        while (secondCheckBool = true)
                        {
                            if (kvp.Key.SlotNumber == itemKey)
                            {
                                if (Balance > kvp.Key.Price)
                                {
                                    Console.WriteLine($"You have chosen {kvp.Key.ItemName}, are you sure you want to buy this item?");
                                    Console.WriteLine("type Y to confirm purchase, or N to stop purchase);
                                    Char feedMoneyYorN = Console.ReadKey().KeyChar;
                                    if (feedMoneyYorN == 'Y' || feedMoneyYorN == 'y')
                                    {
                                        Console.WriteLine("Please f")
                                        string moneyFedToBeCast = Console.ReadLine();
                                        //will complete after refactoring FeedMoney
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money has been fed into the machine, please feed more or choose another item");
                                    PurchaseMenu.GoToPurchaseMenu(vendingMachine);
                                }
                            }
                            else
                            {

                            }
                        }
                        
                        itemCheckBool = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The item key entered does not correspond to an existing item in the vending machine, please re-enter");
                        itemKey = Console.ReadLine();
                        itemCheckBool = true;
                    }
        */
            return true; //TODO Add method
        } 
    } 
}

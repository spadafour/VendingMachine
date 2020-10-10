using Capstone.Classes.Menus;
using Capstone.Classes.VendItems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //Parameters
        public decimal Balance { get; private set; } = 0;
        private Dictionary<VendItem, int> VendItemInventory { get; set; } = new Dictionary<VendItem, int>();
        //TODO Add public string[] BillReader as holder for bills to recognize
        //TODO Maybe Generate Coin Purse Here? Just an array that holds possible coins? public Coin[] coinTypes


        //Methods
        public decimal GetBalance() //Returns Balance as decimal
        {
            return Balance;
        }

        public bool AddItemToInventory(VendItem item, int startingStock) //Adds VendItem object, startingStock int to VendItemInventory dictionary
        {
            VendItemInventory.Add(item, startingStock);
            return true;
        }

        public Dictionary<VendItem, int> GetVendItemInventory() //Returns VendItemInventory dictionary
        {
            return VendItemInventory;
        }

        public void FeedMoney(decimal moneyFed) //Adds to VendingMachine Balance
        {
            Balance += moneyFed;
        }

        public void VendSelectedItem(string itemKey) //VendItem.Quantity--; balance-=VendItem.Price; ConsoleWriteLine VendItem.Name, .Price, Balance, Message(might need if statements for msg?)
            //TODO Clean up method VendSelectedItem() / move some code to submenu
        {
            string lowerCase = itemKey.ToLower();
            bool secondCheckBool = true;
            if (lowerCase.Equals("x"))
            {
                secondCheckBool = false;
            }
            Dictionary<VendItem, int> dummyDictionary = new Dictionary<VendItem, int>(VendItemInventory);
            int counter = 0;
            while (secondCheckBool)
            { 
                foreach (KeyValuePair<VendItem, int> kvp in dummyDictionary)
                {
                    counter++;
                    if (kvp.Key.SlotNumber.ToLower() == itemKey.ToLower())
                    {
                        counter--;
                        if (Balance >= kvp.Key.Price)
                        {
                            Console.WriteLine($"You have chosen {kvp.Key.ItemName}, are you sure you want to buy this item?");
                            Console.Write("type Y to confirm purchase, or N to stop purchase. Any other key will take you back to the purchase menu ");
                            Char confirmPurchase = Console.ReadKey().KeyChar;

                            if (confirmPurchase == 'Y' || confirmPurchase == 'y')
                            {
                                if (kvp.Value > 0)
                                {  
                                    Balance -= kvp.Key.Price;
                                    VendItemInventory[kvp.Key] = kvp.Value - 1;
                                    Console.WriteLine(kvp.Key.Message);
                                    Console.WriteLine();
                                    secondCheckBool = false;
                                }
                                else
                                {
                                    Console.WriteLine("SOLD OUT");
                                }
                            }
                            else if (confirmPurchase == 'N' || confirmPurchase == 'n')
                            {
                                Console.WriteLine("You have successfully canceled your purchase");
                                secondCheckBool = false;
                            }
                            else
                            {
                                Console.WriteLine("You have entered a key other than y or n and are now being returned to the purchase menu");
                                secondCheckBool = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money has been fed into the machine, please feed more or choose another item");
                            secondCheckBool = false;
                        }
                    }
                    else if (counter == dummyDictionary.Count)
                    {
                        Console.WriteLine($"Sorry, there is not an item with slot {itemKey}");
                        secondCheckBool = false;
                    }
                }
            }
            
        }
        public Dictionary<string, int> MakeChange() //Returns changePurse dictionary and Zeroes balance
            //TODO Reconfigure MakeChange() to generate new coin objects inside of changePurse. Alter if statements to Loop through coinpurse to generate change.
            //Maybe make some of this logic its own class?
        {
            Dictionary<string, int> changePurse = new Dictionary<string, int> { { "Quarters", 0 }, { "Dimes", 0 }, { "Nickels", 0 }, { "Pennies", 0 } };
            int currentCentBalance = (int)(Balance * 100);
            if (currentCentBalance >= 25)
            {
                changePurse["Quarters"] = currentCentBalance / 25;
                currentCentBalance %= 25;
            }
            if (currentCentBalance >= 10)
            {
                changePurse["Dimes"] = currentCentBalance / 10;
                currentCentBalance %= 10;
            }
            if (currentCentBalance >=5)
            {
                changePurse["Nickels"] = currentCentBalance / 5;
                currentCentBalance %= 5;
            }
            changePurse["Pennies"] = currentCentBalance;
            currentCentBalance -= currentCentBalance;
            Balance = currentCentBalance;
            return changePurse;
        }
    } 
}

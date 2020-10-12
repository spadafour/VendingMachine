using Capstone.Classes.Menus;
using Capstone.Classes.ReadersAndLoggers;
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

        //Methods
        public bool AddItemToInventory(VendItem item, int startingStock) //Adds VendItem object, startingStock int to VendItemInventory dictionary
        {
            if (startingStock < 0)
            {
                return false;
            }
            else VendItemInventory.Add(item, startingStock);
            return true;
        }

        public Dictionary<VendItem, int> GetVendItemInventory() //Returns VendItemInventory dictionary
        {
            return VendItemInventory;
        }

        public void FeedMoney(decimal moneyFed) //Adds to VendingMachine Balance
        {
            //code is controlled elsewhere to disallow non-bill values, including negative values
            Balance += moneyFed;
        }

        public void VendSelectedItem(VendItem vendKey)
        {
            VendItemInventory[vendKey]--;
            Balance -= vendKey.Price;
        }
        public Dictionary<string, int> MakeChange() //Returns changePurse dictionary and Zeroes balance
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

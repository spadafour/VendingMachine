using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        /*
         * Parameters 
         */

        //running balance of money fed into the machine
        private decimal balance { get; set; }

        //Complete list of Items to vend and the associated key. Key might need to be a string depending on input file. (ex: A3 instead of just 3)
        public Dictionary<int, VendItem> VendItemInventory { get; set; } = new Dictionary<int, VendItem>();

        //Just a running int count of the amount of keys inside of the Vending Machine dictionary
        public int VendItemCount { get { return VendItemInventory.Count; } }


        /*
         * Methods 
         */

        //Display VendItem info using a given key
        public string DisplayVendItemInfo(int vendKey)
        {
            return "Hello World"; //TODO Add method
        }

        //Display LIst of Stocked Products Info
        public string DisplayVendItemList()
        {
            return "Hello World"; //TODO Add method
        }
        //*****Maybe DisplayVendItemInfo() and DisplayVendItemList() can be another class, VendingMachineDisplay????

        //Adds to VendingMachine Balance, sutbtract from Customer.Balance, Log Money with AuditLogger (maybe return string with new balance??)
        public bool FeedMoney()
        {
            return true; //TODO Add method
        }

        //VendItem.Quantity--; balance-=VendItem.Price; ConsoleWriteLine VendItem.Name, .Price, Balance, Message(might need if statements for msg?)
        public bool VendSelectedItem()
        {
            return true; //TODO Add method
        }

        //Make Change Calculates change into quarter, dime, nickel, penny
        public bool MakeChange()
        {
            return true; //TODO Add method
        }
    }
}

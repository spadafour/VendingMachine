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

        public bool FeedMoney() //Adds to VendingMachine Balance, sutbtract from Customer.Balance, Log Money with AuditLogger (maybe return string with new balance??)
        {
            return true; //TODO Add method
        }
        
        public bool VendSelectedItem() //VendItem.Quantity--; balance-=VendItem.Price; ConsoleWriteLine VendItem.Name, .Price, Balance, Message(might need if statements for msg?)
        {
            return true; //TODO Add method
        }
    }
}

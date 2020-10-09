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
        private Dictionary<string[], int> VendItemInventory { get; set; } = new Dictionary<string[], int>();
        public int VendItemCount { get { return VendItemInventory.Count; } }
        public Dictionary<string, string> VendMessage = new Dictionary<string, string>()
        {
            { "Chip", "Crunch Crunch, Yum!" },
            { "Candy", "Munch Munch, Yum!" },
            { "Drink", "Glug Glug, Yum!" },
            { "Gum", "Chew Chew, Yum!" }
        };

        
        //Methods

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

        public decimal GetBalance()
        {
            return Balance;
        }

        public Dictionary<string[], int> GetVendItemInventory()
        {
            return VendItemInventory;
        }
    }
}

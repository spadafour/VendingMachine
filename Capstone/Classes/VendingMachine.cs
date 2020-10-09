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
        //VendItem inside Dictionary: < [Slot, ItemName, Price, FoodType], CurrentStock >
        public int VendItemCount { get { return VendItemInventory.Count; } }
        public Dictionary<string, string> VendMessage = new Dictionary<string, string>()
        {
            { "Chip", "Crunch Crunch, Yum!" },
            { "Candy", "Munch Munch, Yum!" },
            { "Drink", "Glug Glug, Yum!" },
            { "Gum", "Chew Chew, Yum!" }
        };

        
        //Methods
        public decimal GetBalance()
        {
            return Balance;
        }

        public bool AddItemToInventory(string[] item, int startingStock)
        {
            VendItemInventory.Add(item, startingStock);
            return true;
        }

        public Dictionary<string[], int> GetVendItemInventory()
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

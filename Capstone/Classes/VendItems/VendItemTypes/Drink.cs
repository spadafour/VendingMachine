using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.VendItems.VendItemTypes
{
    public class Drink : VendItem
    {
        public Drink(string slotNumber, string itemName, decimal price)
        {
            SlotNumber = slotNumber;
            ItemName = itemName;
            Price = price;
            Message = "Glug Glug, Yum!";
        }
    }
}

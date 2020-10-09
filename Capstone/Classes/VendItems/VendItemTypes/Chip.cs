using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.VendItems.VendItemTypes
{
    public class Chip : VendItem
    {
        public Chip (string slotNumber, string itemName, decimal price)
        {
            SlotNumber = slotNumber;
            ItemName = itemName;
            Price = price;
            Message = "Crunch Crunch, Yum!";
        }
    }
}
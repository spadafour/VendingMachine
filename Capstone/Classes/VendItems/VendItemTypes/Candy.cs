using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.VendItems.VendItemTypes
{
    public class Candy : VendItem
    {
        public Candy (string slotNumber, string itemName, decimal price)
        {
            SlotNumber = slotNumber;
            ItemName = itemName;
            Price = price;
            Message = "Munch Munch, Yum!";
        }
    }
}
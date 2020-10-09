using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.VendItems.VendItemTypes
{
    public class Gum : VendItem
    {
        public Gum (string slotNumber, string itemName, decimal price)
        {
            SlotNumber = slotNumber;
            ItemName = itemName;
            Price = price;
            Message = "Chew Chew, Yum!";
        }
    }
}

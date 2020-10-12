using Capstone.Classes.VendItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class DisplayItemsMenu : IMenu
    {
        VendingMachine Vendomatic { get; }

        public DisplayItemsMenu(VendingMachine vendomatic)
        {
            Vendomatic = vendomatic;
        }

        public bool GoTo()
        {
            foreach (KeyValuePair <VendItem, int> item in Vendomatic.GetVendItemInventory())
            {
                string printItemLine = $"{item.Key.SlotNumber}. {item.Key.ItemName} - {item.Key.Price:C} - ";
                if (item.Value == 0)
                {
                    Console.WriteLine(printItemLine + "SOLD OUT");
                }
                else Console.WriteLine(printItemLine + Vendomatic.GetVendItemInventory()[item.Key]);
            }
            Console.WriteLine();
            return true;
        }
    }
}

using Capstone.Classes.VendItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus.SubMenus
{
    public class DisplayItemsMenu : UI
    {
        public void GoToDisplayItemsMenu()
        {
            foreach (KeyValuePair <VendItem, int> item in Vendomatic.GetVendItemInventory())
            {
                string printItemLine = $"{item.Key.SlotNumber}. {item.Key.ItemName} - {item.Key.Price:C} - {Vendomatic.GetVendItemInventory()[item.Key]}";
                if (item.Value == 0)
                {
                    Console.WriteLine(printItemLine + " - SOLD OUT");
                }
                else Console.WriteLine(printItemLine);
            }
            Console.WriteLine(System.Environment.NewLine);
        }
    }
}

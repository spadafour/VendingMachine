using Capstone.Classes.VendItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus.SubMenus
{
    public class DisplayItemsMenu
    {
        public static bool GoToDisplayItemsMenu(Dictionary<VendItem, int> vendItems)
        {
            foreach (KeyValuePair <VendItem, int> item in vendItems)
            {
                string printItemLine = $"{item.Key.SlotNumber}. {item.Key.ItemName} - {item.Key.Price:C}";
                if (item.Value == 0)
                {
                    Console.WriteLine(printItemLine + " - SOLD OUT");
                }
                else Console.WriteLine(printItemLine);
            }
            Console.WriteLine(System.Environment.NewLine);
            return true;
        }
    }
}

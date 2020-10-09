using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus.SubMenus
{
    public class DisplayItemsMenu
    {
        public static bool GoToDisplayItemsMenu(Dictionary<string[], int> vendItems)
        {
            foreach (KeyValuePair<string[], int> item in vendItems)
            {
                string printItemLine = $"{item.Key[0]}. {item.Key[1]} - ${item.Key[2]}";
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

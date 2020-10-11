using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class SelectProductMenu : IMenu
    {
        VendingMachine Vendomatic { get; }
        AuditLogger Auditor { get; }
        public SelectProductMenu(VendingMachine vendomatic, AuditLogger autidor)
        {
            Vendomatic = vendomatic;
            Auditor = autidor;
        }
        public bool GoTo()
        {
            Console.WriteLine("Please select an item number from the following list of products");
            Console.WriteLine($"A balance of {Vendomatic.Balance} remains in the vending machine");
            //rspadafore: Changed how to access Display Items Menu
            DisplayItemsMenu displayItemsMenu = new DisplayItemsMenu(Vendomatic);
            displayItemsMenu.GoTo();
            Console.WriteLine("Now input the key of the item you would like to purchase, or press X to return to purchase menu");
            string itemKey = Console.ReadLine();
            Auditor.HoldBalance(Vendomatic.Balance);
            Vendomatic.VendSelectedItem(itemKey, Auditor);
            return true;
        }
    }
}

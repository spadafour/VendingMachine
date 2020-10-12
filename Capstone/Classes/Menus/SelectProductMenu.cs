using Capstone.Classes.ReadersAndLoggers;
using Capstone.Classes.VendItems;
using Capstone.Classes.VendItems.VendItemTypes;
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
            Console.WriteLine($"Balance: {Vendomatic.Balance}");
            DisplayItemsMenu displayItemsMenu = new DisplayItemsMenu(Vendomatic);
            displayItemsMenu.GoTo();
            string itemSelect;
            Console.Write("Please select an item number[Letter and Number]: ");
            itemSelect = Console.ReadLine().ToLower();

            bool pickedValidKey = false;
            bool isSoldOut = false;
            VendItem validVendKey = new Chip("", "", 0);
            foreach (VendItem vendItem in Vendomatic.GetVendItemInventory().Keys)
            {
                if (vendItem.SlotNumber.ToLower() == itemSelect && Vendomatic.GetVendItemInventory()[vendItem] > 0)
                {
                    pickedValidKey = true;
                    validVendKey = vendItem;
                    
                }
                else if (vendItem.SlotNumber.ToLower() == itemSelect && Vendomatic.GetVendItemInventory()[vendItem] == 0)
                {
                    pickedValidKey = true;
                    validVendKey = vendItem;
                    isSoldOut = true;
                }
            }

            if (pickedValidKey && isSoldOut)
            {
                Console.WriteLine("Sorry, that item is SOLD OUT.\n");
            }
            else if (pickedValidKey && (!isSoldOut) && Vendomatic.Balance < validVendKey.Price)
            {
                Console.WriteLine("Sorry, not enough Money to vend.\n");
            }
            else if (pickedValidKey && (!isSoldOut) && Vendomatic.Balance >= validVendKey.Price)
            {
                Auditor.HoldBalance(Vendomatic.Balance);
                Vendomatic.VendSelectedItem(validVendKey);
                Auditor.LogItemVended(validVendKey, Vendomatic.Balance);
                Console.WriteLine($"Dispensing {validVendKey.ItemName} ({validVendKey.Price:C2}) - Remaining Balance: {Vendomatic.Balance:C2}");
                Console.WriteLine(validVendKey.Message + "\n");
            }
            else
            {
                Console.WriteLine("Invalid Selection.\n");
            }

            return true;
        }
    }
}

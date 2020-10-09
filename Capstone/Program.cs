using Capstone.Classes;
using Capstone.Classes.Menus;
using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            ui.UIStart();



            ////This code Writes VendingMachineInventory To Screen
            //foreach(KeyValuePair<string, string[]> kvp in vendingMachine.VendItemInventory)
            //{
            //    Console.WriteLine($"{kvp.Key} {kvp.Value[0]}");
            //}
        }
    }
}

/*Hey!
 * 
 * Here's an update to what's been added/changed.
 * 
 * 
 * Stocker (Prob the most important small change)
 * The way we were adding info into the VendingMachineDictionary was good but was causing some access roadblocks the way it was set up; I was hoping to clear this with everyone first.
 *     This will make access hopefully more clear and easier for all of us in the long run.
 *     
 * This was how we initially how we had each key-value-pair set up:
 * <string, string[]> = <slot, [name, price, snackType, currentStockCount]>
 * This is how the key-value-pair is now extracted:
 * <string[], int> = <[slot, name, price, snackType], currentStockCount>
 * 
 * This allows us to access the current stock count without having to convert from string to decimal and then back to string everytime we want to access that number. I also left this note
 *     below the dictionary on the VendingMachine Class.
 * 
 * 
 * 
 * Menus
 * The main menu is set up to talk with all menus currently under the SubMenus Classes folder. I made methods that do nothing for the incomplete menus just to get rid of red squiggles.
 *     Please use the method names I left so Main Menu doesn't crack.
 * DisplayItemsMenu is totally functional and coded.
 * FinishTransactionMenu was created as an "are you sure you want to exit?" catch, and to handle change dispersal there (There's a method in VendingMachine to return balance
 *     to do this). It's currently empty tho. Feel free to start building this out.
 * PurchaseMenu is totally open as well.
 * UI is also totally done. We might want to merge Main Menu with UI menu? Something to think about.
 * 
 * 
 * 
 * VendingMachine
 * I started gutting the extra placeholder methods that aren't relevant anymore. I also made a few parameters private and set up methods to access that info, so that might be worth taking a
 *     look at (not too sure yet about permissions on some of that stuff).
 * I also added a new Dictionary called VendMessage to hold the messages to print when product is vended. Feel free to use it in the Purchase Menu or not!
 *     We can make a method for it too if need be.
 * I left two methods open here that we can build out for the Purchase menu if we want. They can happen here, or they can go somewhere else.
 * 
 * 
 * 
 * Still missing:
 * Still need to build out AuditLogger Class
 * Test Files
 * Should we consider the challenge question?
 * 
 * 
 * 
 * That's it! See ya tomorrow morning! :)
 */


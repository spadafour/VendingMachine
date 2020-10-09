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
        }
    }
}

/*Hey!
 * 
 * Here's an update to what's been added/changed.
 * 
 * 
 * Stocker/Reintroducing VendItem Classes and SubcLasses (Prob the most important change)
 * I looked back to Tom's building a deck of cards to see how he generated a new Deck class using a for loop to iterate through Card classes. Andy, you were right, it is doable with
 *     repeating viable names.
 *     
 * This was how we initially had each key-value-pair set up:
 * <string, string[]> = <slot, [name, price, snackType, currentStockCount]>
 * 
 * This is how the key-value-pair is now extracted:
 * <VendItem, int> = <{slot, itemName, price, (message in subclass)}, currentStockCount>
 * 
 * Check out the VendItems Class folders for those (VendItem is set as abstract for now, the concrete classes are the subclasses holding the specific output messages).
 * The VendingMachine Class Dictionary, VendItemInventory (and associated methods) were altered slightly to reflect this change.
 * 
 * 
 * 
 * Menus
 * The main menu is set up to talk with all menus currently under the SubMenus Classes folder. I made methods that do nothing for the incomplete menus just to get rid of red squiggles.
 * DisplayItemsMenu is totally functional and coded. You can test it out, too, in debug mode!
 * FinishTransactionMenu was created as an "are you sure you want to exit?" catch, and maybe to handle change dispersal there (There's a method in VendingMachine to return balance
 *     to do this if we want to go that route). It's currently empty tho. Feel free to start building this out.
 * PurchaseMenu is totally open as well.
 * UI is totally done, but there's barely anything there anyway. We might want to merge Main Menu with UI menu? Something to think about.
 * 
 * 
 * 
 * VendingMachine
 * I started gutting the extra placeholder methods that aren't relevant anymore. I also made a few parameters private and set up methods to access that info, so that might be worth taking a
 *     look (not too sure yet about permissions on some of that stuff).
 * I left two potential methods open here that we can build out for the Purchase menu if we want. They can happen here, or they can go somewhere else.
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


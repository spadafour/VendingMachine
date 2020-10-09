using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus.SubMenus
{
    public class FinishTransactionMenu
    {
        public static bool GoToFinishTransactionMenu(VendingMachine vendingMachine)
        {
            Console.WriteLine("Are you sure you want to exit? 1=Yes / 2=No: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool isOption = false;
            do
            {
                switch (userSelection)
                {
                    case '1': //Yes
                        vendingMachine.MakeChange();
                        isOption = true; break;

                }
            }
            while (!isOption);

            return true;
        }
    }
}

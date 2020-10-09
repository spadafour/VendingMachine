using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus.SubMenus
{
    public class ExitMenu
    {
        public static bool GoToExitMenu()
        {
            Console.Write("Are you sure you want to quit? 1=Yes / 2=No: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine(System.Environment.NewLine);
            bool isOption = false;
            bool shouldExit = false;
            do
            {
                switch (userSelection)
                {
                    case '1': //Yes
                        userSelection = '0'; isOption = true; shouldExit = true; break;
                    case '2': //No
                        Console.WriteLine("Returning to Main Menu");
                        userSelection = '0'; isOption = true; shouldExit = false; break;
                    default:
                        Console.Write("Are you sure you want to quit? 1=Yes / 2=No: ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine(System.Environment.NewLine);
                        isOption = false; break;
                }
            }
            while (!isOption);

            return shouldExit;
        }
    }
}

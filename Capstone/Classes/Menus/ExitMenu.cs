using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class ExitMenu : IMenu
    {
        public bool GoTo()
        {
            Console.Write("Are you sure you want to quit? 1=Yes / 2=No: ");
            Char userSelection = Console.ReadKey().KeyChar;
            Console.WriteLine();
            bool answered1Or2 = false;
            bool keepRunning = true;
            do
            {
                switch (userSelection)
                {
                    case '1': //Yes
                        answered1Or2 = true; keepRunning = false; break;
                    case '2': //No
                        Console.WriteLine("Returning to Main Menu\n");
                        answered1Or2 = true; keepRunning = true; break;
                    default:
                        Console.Write("Are you sure you want to quit? 1=Yes / 2=No: ");
                        userSelection = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        answered1Or2 = false; break;
                }
            }
            while (!answered1Or2);

            return keepRunning;
        }
    }
}

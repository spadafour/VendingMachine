using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Capstone.Classes.Menus
{
    class MainMenu : IMenu
    {
        public bool GoTo()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.Write("Selection: ");
            return true;
        }
    }
}

using Capstone.Classes.ReadersAndLoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Menus
{
    public class UI
    {
        public VendingMachine VendingMachine = new VendingMachine();
        public void UIStart()
        {
            Stocker stocker = new Stocker();
            VendingMachine = stocker.GenerateNewVendingMachine();

            MainMenu.GoToMainMenu(VendingMachine);


        }
    }
}

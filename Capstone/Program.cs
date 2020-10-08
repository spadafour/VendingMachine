using Capstone.Classes;
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
            Stocker stocker = new Stocker();
            VendingMachine vendingMachine = stocker.StockNewMachine();
            



            ////This code Writes VendingMachineInventory To Screen
            //foreach(KeyValuePair<string, string[]> kvp in vendingMachine.VendItemInventory)
            //{
            //    Console.WriteLine($"{kvp.Key} {kvp.Value[0]}");
            //}
        }
    }
}

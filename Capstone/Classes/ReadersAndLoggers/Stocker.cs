using Capstone.Classes.Menus;
using Capstone.Classes.VendItems;
using Capstone.Classes.VendItems.VendItemTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes.ReadersAndLoggers
{
    public class Stocker
    {
        public int StartingStock { get; set; } = 5;
        private VendingMachine VendingMachineForStocker = new VendingMachine();

        public VendingMachine StockVendingMachine()
        {
            Queue<string[]> itemQueue = new Queue<string[]>();

            //FilePath for Input .CSV File to use with StreamReader
            string directory = Environment.CurrentDirectory;
            string file = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, file);

            //Add each line to queue to be later added VendingMachine.VendItemInventory Dictionary
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string readLine = sr.ReadLine();
                            string[] itemInfo = readLine.Split("|");
                            itemQueue.Enqueue(itemInfo);
                        }
                        catch (Exception e)
                        {
                            Console.Write("Unable to add this to Vending Machine: ");
                            Console.WriteLine(sr.ReadLine());
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file");
                Console.WriteLine(e.Message);
            }

            StockItemQueueIntoVendingMachine(itemQueue);

            return VendingMachineForStocker;
        }

        public bool StockItemQueueIntoVendingMachine(Queue<string[]> itemQueue)
        {
            bool canStockNoIssue = true;
            try
            {
                foreach (string[] item in itemQueue)
                {
                    switch (item[3].ToLower())
                    {
                        case "chip":
                            VendItem itemChip = new Chip(item[0], item[1], decimal.Parse(item[2]));
                            VendingMachineForStocker.AddItemToInventory(itemChip, StartingStock); break;
                        case "candy":
                            VendItem itemCandy = new Candy(item[0], item[1], decimal.Parse(item[2]));
                            VendingMachineForStocker.AddItemToInventory(itemCandy, StartingStock); break;
                        case "drink":
                            VendItem itemDrink = new Drink(item[0], item[1], decimal.Parse(item[2]));
                            VendingMachineForStocker.AddItemToInventory(itemDrink, StartingStock); break;
                        case "gum":
                            VendItem itemGum = new Gum(item[0], item[1], decimal.Parse(item[2]));
                            VendingMachineForStocker.AddItemToInventory(itemGum, StartingStock); break;
                        default:
                            Console.WriteLine("Unable to Add Item To Vend Inventory"); break;
                    }

                }
            }
            catch
            {
                Console.WriteLine("Sorry, we're having technical difficulties!");
                Console.WriteLine("The Vending Machine was not able to be properly stocked. Please check input file.");
                canStockNoIssue = false;
            }
            return canStockNoIssue;
        }
    }
}

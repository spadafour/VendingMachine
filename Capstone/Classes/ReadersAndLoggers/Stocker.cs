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
        public VendingMachine StockNewMachine()
        {
            
            VendingMachine vendingMachine = new VendingMachine();
            Queue<string[]> itemQueue = new Queue<string[]>();
            string directory = Environment.CurrentDirectory;
            string file = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, file);
            
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string readLine = sr.ReadLine() + $"|{StartingStock}";
                        string[] itemInfo = readLine.Split("|");
                        itemQueue.Enqueue(itemInfo);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file");
                Console.WriteLine(e.Message);
            }

            foreach (string[] item in itemQueue)
            {
                string[] itemInfoMinusSlot = new string[item.Length - 1];
                for (int i = 0; i < item.Length - 2; i++)
                {
                    itemInfoMinusSlot[i] = item[i + 1];
                }
                vendingMachine.VendItemInventory.Add(item[0], itemInfoMinusSlot);
            }

            return vendingMachine;
        }
    }
}

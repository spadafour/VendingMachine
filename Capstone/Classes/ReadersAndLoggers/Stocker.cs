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
        public VendingMachine GenerateNewVendingMachine()
        {
            
            VendingMachine vendingMachine = new VendingMachine();
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

            //Add the queued items to the Dictionary in VendingMachine as Key. Use int Starting Stock as Value
            foreach (string[] item in itemQueue)
            {
                vendingMachine.VendItemInventory.Add(item, StartingStock);
            }

            //Output is the newly-generated Vending Machine Object
            return vendingMachine;
        }
    }
}

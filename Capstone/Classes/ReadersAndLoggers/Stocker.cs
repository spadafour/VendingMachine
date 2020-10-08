using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Capstone.Classes.ReadersAndLoggers
{
    public class Stocker
    {
        /*
         * Methods
         */
        public void StockNewMachine()
        {
            VendingMachine vendingMachine = new VendingMachine();
            string directory = Environment.CurrentDirectory;
            string file = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, file);
            
            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string readLine = sr.ReadLine();
                    string[] itemInfo = readLine.Split("|");
                    string vendItemName = itemInfo[0];
                    VendItem vendItem = new VendItem(); //consider way to iterate variable name
                    vendItem.ItemNumber = itemInfo[0];
                    vendItem.Name = itemInfo[1];
                    vendItem.Price = decimal.Parse(itemInfo[2]);
                    vendItem.Type = itemInfo[3];
                    vendItem.Quantity = 5;
                }
            }
        }

        //reads from input text, creates a new VendingMachine
        //public VendingMachine StockNewMachine()
        //{
        //    return VendingMachine; //TODO Add method
        //}
    }
}

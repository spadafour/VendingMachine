using Capstone.Classes.VendItems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Capstone.Classes.ReadersAndLoggers
{
    public class AuditLogger
    {
        private Queue<string> AuditLog { get; set; } = new Queue<string>();
        private Dictionary<string, int> SalesReport { get; set; } = new Dictionary<string, int>();
        private decimal PreBalanceHold { get; set; }
        private string TimeStamp { get; set; }

        public bool LogMoneyIn(decimal moneyFed, decimal vendBalance)
        {
            TimeStamp = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US"));
            AuditLog.Enqueue($"{TimeStamp} FEED MONEY: {moneyFed:C2} {vendBalance:C2}");
            return true;
        }

        public bool HoldBalance(decimal vendBalance)
        {
            PreBalanceHold = vendBalance;
            return true;
        }

        public bool LogItemVended(VendItem itemVended, decimal vendBalance)
        {
            //For AuditLog
            TimeStamp = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US"));
            AuditLog.Enqueue($"{TimeStamp} {itemVended.ItemName} {itemVended.SlotNumber} {PreBalanceHold:C2} {vendBalance:C2}");

            //For Sales Report
            if (SalesReport.ContainsKey(itemVended.ItemName))
            {
                SalesReport[itemVended.ItemName]++;
            }
            else
            {
                SalesReport.Add(itemVended.ItemName, 1);
            }
            return true;
        }

        public bool LogChangeMade(decimal vendBalance)
        {
            TimeStamp = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US"));
            AuditLog.Enqueue($"{TimeStamp} GIVE CHANGE: {PreBalanceHold:C2} {vendBalance:C2}");
            return true;
        }

        public Queue<string> GetAuditLogTest()
        {
            return AuditLog;
        }

        public void AuditWriter()
        {
            string directory = Environment.CurrentDirectory;
            string file = "AuditLog.txt";
            string fullPath = Path.Combine(directory, file);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    int countHolder = AuditLog.Count;
                    for (int i = 0; i < countHolder; i++)
                    {
                        sw.WriteLine(AuditLog.Dequeue());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while writing to Audit File: ");
                Console.WriteLine(e.Message);
            }
            
        }

        public bool SalesReportWriter()
        {
            string directory = Environment.CurrentDirectory;
            string file = $"SalesReport_{DateTime.Now.ToString("MM-dd-yyyy-HH.mm.ss")}.txt";
            string fullPath = Path.Combine(directory, file);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    foreach (KeyValuePair<string, int> salesOfProd in SalesReport)
                    {
                        sw.WriteLine($"{salesOfProd.Key}|{salesOfProd.Value}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while writing to Sales Report: ");
                Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}

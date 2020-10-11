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

        public bool LogItemVended(VendItem vendItem, decimal vendBalance)
        {
            TimeStamp = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US"));
            AuditLog.Enqueue($"{TimeStamp} {vendItem.ItemName} {vendItem.SlotNumber} {PreBalanceHold:C2} {vendBalance:C2}");
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
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                int countHolder = AuditLog.Count;
                for (int i = 0; i < countHolder; i++)
                {
                    sw.WriteLine(AuditLog.Dequeue());
                }
            }
        }
    }
}

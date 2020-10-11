using Capstone.Classes.ReadersAndLoggers;
using Capstone.Classes.VendItems;
using Capstone.Classes.VendItems.VendItemTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.ReadersAndLoggersTests
{
    [TestClass]
    public class AuditLoggerTests
    {
        [TestMethod]
        public void LogMoneyIn()
        {
            AuditLogger auditLogger = new AuditLogger();
            decimal moneyFed = 3.00M;
            decimal vendBalance = 5.00M;
            auditLogger.LogMoneyIn(moneyFed, vendBalance);
           
            string result = auditLogger.GetAuditLogTest().Dequeue();
            if (result.Contains($"FEED MONEY: {moneyFed:C2} {vendBalance:C2}")) 
                {
                result = $"FEED MONEY: {moneyFed:C2} {vendBalance:C2}";
            }
            string expected = $"FEED MONEY: {moneyFed:C2} {vendBalance:C2}";
            Assert.AreEqual(expected, result);
        }
    }
}
       
        

            
           




        
    


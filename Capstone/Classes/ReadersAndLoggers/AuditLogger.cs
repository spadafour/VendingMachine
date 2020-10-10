using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.ReadersAndLoggers
{
    public class AuditLogger
    {
        private Queue<string> AuditLog { get; set; } = new Queue<string>();
        private int PreBalanceHold { get; set; }

        public bool LogMoneyIn(int moneyFed, decimal vendBalance)
        {
            AuditLog.Enqueue($"{DateTime.Now} - FEED MONEY: {moneyFed} - BALANCE: {vendBalance}");
            return true;
        }

        //Date, Time, ProductVended, ProductSlot, BalanceBefore, BalanceAfter
        public bool LogItemVended()
        {
            return true; //TODO Add method
        }

        public bool HoldBalance(int vendBalance)
        {
            PreBalanceHold = vendBalance;
            return true;
        }
        
        //Date, Time, GIVECHANGE, BalanceBefore, BalanceAfter(Should be 0)
        public bool LogChangeMade()
        {
            return true; //TODO Add method
        }
    }
}

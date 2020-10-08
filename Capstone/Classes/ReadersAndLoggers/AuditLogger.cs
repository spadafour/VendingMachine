using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.ReadersAndLoggers
{
    public class AuditLogger
    {
        /*
         * Parameters
         */

        //Holds text to print to the Audit Document
        public Queue<string> AuditLog { get; set; } = new Queue<string>();


        /*
         * Methods
         */

        //Date, Time, FEED MONEY, How much money in, VendingMachine.Balance
        public bool LogMoneyIn()
        {
            return true; //TODO Add method
        }

        //Date, Time, ProductVended, ProductSlot, BalanceBefore, BalanceAfter
        public bool LogItemVended()
        {
            return true; //TODO Add method
        }

        //Date, Time, GIVECHANGE, BalanceBefore, BalanceAfter(Should be 0)
        public bool LogChangeMade()
        {
            return true; //TODO Add method
        }
    }
}

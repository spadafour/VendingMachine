using Capstone.Classes.ReadersAndLoggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.ReadersAndLoggersTests
{
    [TestClass]
    public class StockerTests
    {
        [TestMethod]
        public void StartingStock()
        {
            Stocker stocker = new Stocker();
            int expected = 5;
            int result = stocker.StartingStock;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StockItemQueueIntoVendingMachineTest()
        {
            Stocker stocker = new Stocker();

            //Happy Path
            Queue<string[]> queueTest = new Queue<string[]>();
            queueTest.Enqueue(new string[4] { "A1", "Potato Crisps", "3.05", "Chip" });
            queueTest.Enqueue(new string[4] { "D4", "Triplemint", "0.75", "Gum" });

            bool result = stocker.StockItemQueueIntoVendingMachine(queueTest);
            bool expected = true;

            Assert.AreEqual(expected, result);


            //Exceptions
            queueTest = new Queue<string[]>();
            queueTest.Enqueue(new string[4] { "", "", "", "" });
            queueTest.Enqueue(new string[4] { null, null, null, null });
            queueTest.Enqueue(new string[1] { "A1" });
            queueTest.Enqueue(new string[5] { "A1", "Potato Crisps", "3.05", "Chip", "Candy" });

            result = stocker.StockItemQueueIntoVendingMachine(queueTest);
            expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}

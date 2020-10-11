using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        //Testing Balance
        [TestMethod]
        public void BalanceAtStart()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal expected = 0;
            decimal result = vendingMachine.Balance;

            Assert.AreEqual(expected, result);
        }
        //TODO: Test for VendSelectedItem

        //FeedMoney test
        [TestMethod]
        public void FeedMoney()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(10);
            decimal expected = 10;
            decimal result = vendingMachine.Balance;

            Assert.AreEqual(expected, result);

        }

        //Testing MakeChange Dictionary, but pretty sure this isn't right even though it passes...
        [TestMethod]
        public void MakeChange()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(10);
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "Quarters", 40 }, { "Dimes", 0 }, { "Nickels", 0 }, { "Pennies", 0 }
            };
            Dictionary<string, int> result = vendingMachine.MakeChange();

            CollectionAssert.AreEqual(expected, result);

            vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(11.61M);
            expected = new Dictionary<string, int>
            {
                { "Quarters", 46 }, { "Dimes", 1 }, { "Nickels", 0 }, { "Pennies", 1 }
            };
            result = vendingMachine.MakeChange();

            CollectionAssert.AreEqual(expected, result);

            vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(1.05M);
            expected = new Dictionary<string, int>
            {
                { "Quarters", 4 }, { "Dimes", 0 }, { "Nickels", 1 }, { "Pennies", 0 }
            };
            result = vendingMachine.MakeChange();

            CollectionAssert.AreEqual(expected, result);

            //TODO: Testing MakeChange Dictionary exceptions below, but I actually don't know how to go about doing this for a dictionary...

        }
    }
}


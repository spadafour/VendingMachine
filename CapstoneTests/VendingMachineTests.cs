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
        public void Balance()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal expected = 0;
            decimal result = vendingMachine.Balance;

            Assert.AreEqual(expected, result);
        }
        //Testing MakeChange Dictionary, but pretty sure this isn't right even though it passes...
        [TestMethod]
        public void MakeChange()
        {
            VendingMachine vendingMachine = new Vendingmachine();
            Dictionary<string, int> expected = vendingMachine.MakeChange();
            Dictionary<string, int> result = vendingMachine.MakeChange();

            CollectionAssert.AreEqual(expected, result);

            //Testing MakeChange Dictionary exceptions, but I actually don't know how to go about doing this for a dictionary...
        }
    }
}


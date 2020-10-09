using Capstone.Classes.VendItems.VendItemTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.VendItemsTests.VendItemTypesTests
{
    [TestClass]
    public class DrinkTests
    {
        [TestMethod]
        public void Drink()
        {
            Drink drink = new Drink("C1", "Cola", 1.25M);
            string expected = "C1";
            string result = drink.SlotNumber;

            Assert.AreEqual(expected, result);

            expected = "Cola";
            result = drink.ItemName;

            Assert.AreEqual(expected, result);

            decimal expected2 = 1.25M;
            decimal result2 = drink.Price;

            Assert.AreEqual(expected2, result2);
        }
    }
}

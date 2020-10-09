using Capstone.Classes.VendItems.VendItemTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.VendItemsTests.VendItemTypesTests
{
    [TestClass]
    public class CandyTests
    {
        [TestMethod]
        public void Candy()
        {
            Candy candy = new Candy("B1", "Moonpie", 1.80M);
            string expected = "B1";
            string result = candy.SlotNumber;

            Assert.AreEqual(expected, result);

            expected = "Moonpie";
            result = candy.ItemName;

            Assert.AreEqual(expected, result);

            decimal expected2 = 1.80M;
            decimal result2 = candy.Price;

            Assert.AreEqual(expected2, result2);
        }
    }
}

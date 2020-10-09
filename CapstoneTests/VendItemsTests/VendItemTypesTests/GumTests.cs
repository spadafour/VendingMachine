using Capstone.Classes.VendItems.VendItemTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.VendItemsTests.VendItemTypesTests
{
    [TestClass]
    public class GumTests
    {
        [TestMethod]
        public void Gum()
        {
            Gum gum = new Gum("D1", "U-Chews", 0.85M);
            string expected = "D1";
            string result = gum.SlotNumber;

            Assert.AreEqual(expected, result);

            expected = "U-Chews";
            result = gum.ItemName;

            Assert.AreEqual(expected, result);

            decimal expected2 = 0.85M;
            decimal result2 = gum.Price;

            Assert.AreEqual(expected2, result2);
        }
    }
}

using Capstone.Classes.VendItems.VendItemTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.VendItemsTests.VendItemTypesTests
{
    [TestClass]
    public class ChipTests
    {
        [TestMethod]
        public void Chip()
        {
            Chip chip = new Chip("A1", "Potato Crisps", 3.05M);
            string expected = "A1";
            string result = chip.SlotNumber;

            Assert.AreEqual(expected, result);

            expected = "Potato Crisps";
            result = chip.ItemName;

            Assert.AreEqual(expected, result);

            decimal expected2 = 3.05M;
            decimal result2 = chip.Price;

            Assert.AreEqual(expected2, result2);
        }
    }
}

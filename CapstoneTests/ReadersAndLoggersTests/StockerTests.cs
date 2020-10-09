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
    }
}

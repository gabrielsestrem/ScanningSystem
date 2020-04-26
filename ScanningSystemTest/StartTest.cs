using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScanningSystemTest
{
    [TestClass]
    public class StartTest
    {
        [TestMethod]
        //Required test cases
        [DataRow(new string[] { "A", "B", "C", "D", "A", "B", "A" }, "13.25")]
        [DataRow(new string[] { "C", "C", "C", "C", "C", "C", "C" }, "6.00")]
        [DataRow(new string[] { "A", "B", "C", "D" }, "7.25")]
        // Invalid products (WXZ), skip them
        [DataRow(new string[] { "A", "W", "B", "C", "X", "D", "Z" }, "7.25")]
        // All invalid products, return 0
        [DataRow(new string[] { "Z", "Z", "Z", "Z", "Z", "Z", "Z" }, "0")]
        public void Test_CheckOut(string[] products, string total)
        {
            // Arrange
            decimal expected = Convert.ToDecimal(total);

            // Act
            decimal actual = ScanningSystemClassLibrary.Start.StartCheckout(products);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FF7_Speedrun_Control_Logic;

namespace FF7_Speedrun_Control_Logic.Tests
{
    /// <summary>
    /// Please follow the standard Arrange/Act/Assert pattern
    /// </summary>
    [TestClass]
    public class HexConverterTests
    {
        [TestMethod]
        public void ConvertDecimalToHex()
        {
            // Arrange
            HexConverter converter = new HexConverter();
            int val1 = 192;

            // Act
            string result1 = converter.ToHex(val1);

            // Assert
            Assert.AreEqual("C0", result1);
        }

        [TestMethod]
        public void ConvertHexToDecimal()
        {
            // Arrange
            HexConverter converter = new HexConverter();
            string val1 = "C0";

            // Act
            int result1 = converter.ToDec(val1);

            // Assert
            Assert.AreEqual(192, result1);
        }
    }
}

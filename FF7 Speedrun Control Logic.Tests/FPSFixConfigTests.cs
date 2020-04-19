using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FF7_Speedrun_Control_Logic;

namespace FF7_Speedrun_Control_Logic.Tests
{
    /// <summary>
    /// Please follow the standard Arrange/Act/Assert pattern
    /// </summary>
    [TestClass]
    public class FPSFixConfigTests
    {
        [TestMethod]
        public void ConvertDecimalToFileOutputReadyHex()
        {
            HexConverter converter = new HexConverter(); // TODO: Mock me
            FPSFixConfig config = new FPSFixConfig(converter);
            int dec = 192;
            
            string result = config.GetNewHexValue(dec);
            
            Assert.AreEqual("000000000000C040", result);
        }

        [TestMethod]
        public void GetFullStringForConfigFile()
        {

        }
    }
}

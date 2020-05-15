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
            // TODO: Use relative path!
            string path = @"D:\Dev\VS2017\FF7 Speedrun Control\FF7 Speedrun Control UI\FPSFix\HL_Files\Hext_in\ff7.txt";
            HexConverter converter = new HexConverter(); // TODO: Mock me
            FPSFixConfig config = new FPSFixConfig(path, converter);
            int dec = 192;
            
            string result = config.GetNewHexValue(dec);
            
            Assert.AreEqual("000000000000C040", result);
        }

        [TestMethod]
        public void ConvertHexFromFileToDecimalValue()
        {
            // TODO: Use relative path!
            string path = @"D:\Dev\VS2017\FF7 Speedrun Control\FF7 Speedrun Control UI\FPSFix\HL_Files\Hext_in\ff7.txt";
            HexConverter converter = new HexConverter(); // TODO: Mock me
            FPSFixConfig config = new FPSFixConfig(path, converter);
            //string hex = "000000000000C040";
            string hex = "000000000000C0";

            int result = config.GetDecimalFromHexValue(hex);

            Assert.AreEqual(192, result);
        }

        [TestMethod]
        public void LoadConfigFile()
        {
            // TODO: Use relative path!
            string path = @"D:\Dev\VS2017\FF7 Speedrun Control\FF7 Speedrun Control UI\FPSFix\HL_Files\Hext_in\ff7.txt";
            HexConverter converter = new HexConverter(); // TODO: Mock me
            FPSFixConfig config = new FPSFixConfig(path, converter);

            config.LoadFile();

            Assert.AreEqual(config.frameRateValue, 192);
        }
    }
}

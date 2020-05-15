using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7_Speedrun_Control_Logic
{
    /* Config file looks like:
       <empty line>
       7b7848 = 000000000000C040
     */
    public class FPSFixConfig
    {
        private string _pathToConfig;
        private HexConverter _hexConverter;
        public int frameRateValue { get; set; }

        public FPSFixConfig(string pathToConfig, HexConverter hexConverter)
        {
            this._pathToConfig = pathToConfig;
            this._hexConverter = hexConverter;
        }

        public string HexPadding {
            get {
                return "000000000000{0}40";
            }
        }

        public void LoadFile()
        {
            // Read file
            using (var sr = new System.IO.StreamReader(_pathToConfig))
            {
                string lines = sr.ReadToEnd();
                // Get value
                string valFromFile = lines.Substring(lines.Length - 16, 14);
                // Store in class
                frameRateValue = GetDecimalFromHexValue(valFromFile);
            }
        }

        public void SaveFile()
        {
            string newFileContent = $"{Environment.NewLine}7b7848 = {GetNewHexValue(frameRateValue)}";
            // Save value back to file.
            using (var sw = new System.IO.StreamWriter(_pathToConfig, false))
            {
                sw.Write(newFileContent);
            }
        }

        public string GetCurrentHexValue()
        {
            // TODO: Maybe don't need this
            throw new NotImplementedException();
        }

        public int GetDecimalFromHexValue(string hex)
        {
            return Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }

        public string GetNewHexValue(int dec)
        {
            return string.Format(HexPadding, _hexConverter.ToHex(dec));
        }
    }
}

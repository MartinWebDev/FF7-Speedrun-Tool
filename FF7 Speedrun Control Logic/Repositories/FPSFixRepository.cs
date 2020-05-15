using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF7_Speedrun_Control_Logic.Utils;

namespace FF7_Speedrun_Control_Logic.Repositories
{
    /* Config file looks like:
         <empty line>
         7b7848 = 000000000000C040
       Empty line might not be needed, but can't be arsed to check
     */
    public class FPSFixRepository
    {
        ConfigRepository config;
        HexConverter hex;
        string HexPadding = "000000000000{0}40";

        public FPSFixRepository(ConfigRepository config, HexConverter hex)
        {
            this.config = config;
            this.hex = hex;
        }

        public int GetFPSFIXValue()
        {
            using (var sr = new System.IO.StreamReader(config.Get("FPSFixConfigFile")))
            {
                string lines = sr.ReadToEnd();
                string valFromFile = lines.Substring(lines.Length - 16, 14);
                return hex.ToDec(valFromFile);
            }
        }

        public void SaveFPSFixValue(int dec)
        {
            string newFileContent = $"{Environment.NewLine}7b7848 = {GetPaddedHexValue(dec)}";
            // Save value back to file.
            using (var sw = new System.IO.StreamWriter(config.Get("FPSFixConfigFile"), false))
            {
                sw.Write(newFileContent);
            }
        }

        private string GetPaddedHexValue(int dec)
        {
            return string.Format(HexPadding, hex.ToHex(dec));
        }
    }
}

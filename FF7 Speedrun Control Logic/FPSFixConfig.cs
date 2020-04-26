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

        public void LoadFile() { throw new NotImplementedException(); }

        public void SaveFile() { throw new NotImplementedException(); }

        public string GetCurrentHexValue() { throw new NotImplementedException(); }

        public int GetDecimalFromHexValue() { throw new NotImplementedException(); }

        public string GetNewHexValue(int dec)
        {
            return string.Format(HexPadding, _hexConverter.ToHex(dec));
        }
    }
}

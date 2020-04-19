using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7_Speedrun_Control_Logic
{
    public class HexConverter
    {
        public string ToHex(int dec)
        {
            return string.Format("{0:x}", dec).ToUpper();
        }

        public int ToDec(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }
    }
}

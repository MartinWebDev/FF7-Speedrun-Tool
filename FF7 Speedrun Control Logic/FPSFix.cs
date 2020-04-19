using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7_Speedrun_Control_Logic
{
    public class FPSFix
    {
        // All the below to be moved to config page or similar.
        private string _FPSFixPath = @"C:\Users\Martin\Desktop\FF7 Speedrun\Tools\FPSFIX\";
        private string _FPSFixExe = @"FPSFIX.exe";
        public string FPSFixPath { get { return _FPSFixPath; } set { _FPSFixPath = value; } }
        public string FPSFixExe { get { return _FPSFixExe; } set { _FPSFixExe = value; } }
        public string FPSFixFullPath { get { return $"{_FPSFixPath}{_FPSFixExe}"; } }

        public void LaunchFPSFix()
        {

        }
    }
}

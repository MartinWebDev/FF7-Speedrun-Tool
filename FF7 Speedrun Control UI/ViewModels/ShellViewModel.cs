using Caliburn.Micro;
using FF7_Speedrun_Control_Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Collections.Specialized;

namespace FF7_Speedrun_Control_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        //// Basic info, this will be changed to detect and/or be configured by user.
        //public string FPSFixPath { get; set; } = @"C:\Users\Martin\Desktop\FF7 Speedrun\Tools\FPSFIX\";
        //public string FPSFixExe { get; set; } = @"FPSFIX.exe";
        //public string FPSFixConfigPath { get; set; } = @"HL_Files\Hext_in\";
        //public string FPSFixConfigFile { get; set; } = @"ff7.txt";
        //public string FFPath { get; set; } = @"D:\Program Files (x86)\Steam\steamapps\common\FINAL FANTASY VII\";
        //public string FFExe { get; set; } = @"ff7_en.exe";
        //// Merged paths
        //public string FPSFixFullPath { get { return $"{FPSFixPath}{FPSFixExe}"; } }
        //public string FPSFixConfigFullPath { get { return $"{FPSFixPath}{FPSFixConfigPath}{FPSFixConfigFile}"; } }
        //public string FFFullPath { get { return $"{FFPath}{FFExe}"; } }
        
        public string ConsoleOutput { get; set; }

        public ShellViewModel()
        {
            string sample = ConfigurationManager.AppSettings.Get("FF7ProcessName");
            ConfigurationManager.AppSettings.Set("FF7ProcessName", "SomethingElse");
        }

        public void OpenStartGameView()
        {
            ActivateItem(new GameViewModel());
        }

        public void OpenFPSFixConfigView()
        {
            ActivateItem(new ConfigViewModel());
        }
    }
}

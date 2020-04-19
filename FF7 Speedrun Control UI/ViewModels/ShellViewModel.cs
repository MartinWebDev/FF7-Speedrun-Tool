using Caliburn.Micro;
using FF7_Speedrun_Control_Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7_Speedrun_Control_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        // All the below to be moved to config page or similar.
        private string _FPSFixPath = @"C:\Users\Martin\Desktop\FF7 Speedrun\Tools\FPSFIX\";
        private string _FPSFixExe = @"FPSFIX.exe";
        private string _FPSFixConfigPath = @"HL_Files\Hext_in\";
        private string _FPSFixConfigFile = @"ff7.txt";
        private string _FFPath = @"D:\Program Files (x86)\Steam\steamapps\common\FINAL FANTASY VII\";
        private string _FFExe = @"ff7_en.exe";

        public string FPSFixPath { get { return _FPSFixPath; } set { _FPSFixPath = value; } }
        public string FPSFixExe { get { return _FPSFixExe; } set { _FPSFixExe = value; } }
        public string FPSFixConfigPath { get { return _FPSFixConfigPath; } set { _FPSFixConfigPath = value; } }
        public string FPSFixConfigFile { get { return _FPSFixConfigFile; } set { _FPSFixConfigFile = value; } }
        public string FFPath { get { return _FFPath; } set { _FFPath = value; } }
        public string FFExe { get { return _FFExe; } set { _FFExe = value; } }

        public string FPSFixFullPath { get { return $"{_FPSFixPath}{_FPSFixExe}"; } }
        public string FPSFixConfigFullPath { get { return $"{_FPSFixPath}{_FPSFixConfigPath}{_FPSFixConfigFile}"; } }
        public string FFFullPath { get { return $"{_FFPath}{_FFExe}"; } }
        
        // TEMP
        public string ConsoleOutput { get; set; } = $"Run started!{Environment.NewLine}Launching FPSFix...{Environment.NewLine}FPSFix waiting...{Environment.NewLine}Launching game.{Environment.NewLine}Game Running. FPSFix exit success.{Environment.NewLine}Waiting for game exit...{Environment.NewLine}Game exit detected, relaunching.Launching FPSFix...{Environment.NewLine}FPSFix waiting...{Environment.NewLine}Launching game.{Environment.NewLine}Game Running. FPSFix exit success.{Environment.NewLine}Waiting for game exit...{Environment.NewLine}Complete Run selected. Stopped listening.{Environment.NewLine}";

        // General process will be as follows:
        /*
         * If we are in "setup" mode, we can adjust the values up and down, which updates the text file. 
         * Launch the fpsfix, then the game, and on exit, do not do anything else. Allow user to adjust further.
         * 
         * If we are in "run" mode, values cannot be changed.
         * Launch fpsfix, launch game, on game exit, relaunch fpsfix, relaunch game. Button on window will allow user to complete run and relaunching will stop.
         */

        public ShellViewModel()
        {
            // Find config file and read.
            // Convert hex to decimal and set variable here. 
        }

        // Get temp default, to come from config and transform from HEX to Decimal.
        private int _frameLockValue = 192;
        public int FrameLockValue
        {
            get {
                return _frameLockValue;
            }
            set
            {
                _frameLockValue = value;
                NotifyOfPropertyChange(() => FrameLockValue);
            }
        }

        public void IncreaseFrameLock()
        {
            FrameLockValue += 1;
        }

        public void DecreaseFrameLock()
        {
            FrameLockValue -= 1;
        }

        public void StartGame()
        {
            ExecuteAsAdmin(FPSFixFullPath);

            ProcessHandler proc = new ProcessHandler("ff7_en");
            proc.AttachedProcess += Proc_AttachedProcess;

            ////var processes = Process.GetProcesses().Where(x => x.ProcessName.ToLower().Contains("ff7"));
            //var process = Process.GetProcesses().Where(x => x.ProcessName == "FF7_Launcher").FirstOrDefault();
            //NotifyOnProcessExits(process, () => {
            //    UpdateConsole("Process has exited");
            //});

            //ConsoleOutput = "Game starting";
            //NotifyOfPropertyChange(() => ConsoleOutput);

            //ProcessHandler procHandler = new ProcessHandler("ff7_en");
            //procHandler.AttachedProcess += ProcHandler_AttachedProcess;
            //procHandler.AttachToProcess();




            //ProcessStartInfo start_info = new ProcessStartInfo(FFFullPath);
            ////start_info.WindowStyle = ProcessWindowStyle.Maximized;

            //Process proc = new Process();
            //proc.StartInfo = start_info;
            //proc.Start();

            ////proc.WaitForExit();
            //proc.Exited += Proc_Exited;

            //UpdateConsole("Exit detected");
        }

        private void Proc_AttachedProcess(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        private void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
            proc.Exited += Proc_Exited;
        }

        private void ProcHandler_AttachedProcess(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public static void NotifyOnProcessExits(Process process, System.Action action)
        {
            Task.Run(() => process.WaitForExit()).ContinueWith(t => action());
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            ConsoleOutput += $"{Environment.NewLine}Clicked game end button";
            NotifyOfPropertyChange(() => ConsoleOutput);
        }

        public void UpdateConsole(string newLine)
        {
            ConsoleOutput += newLine + Environment.NewLine;
            NotifyOfPropertyChange(() => ConsoleOutput);
        }

        //public void OpenConfig()
        //{
        //    ActivateItem(new ConfigViewModel());
        //}
    }
}

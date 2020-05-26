using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FF7_Speedrun_Control_Logic.Repositories
{
    public class ProcessRepository
    {
        public delegate void OnProcessEnd(object sender, EventArgs args);
        public event OnProcessEnd ProcessEnded;

        string processName;

        public ProcessRepository(string processName)
        {
            this.processName = processName;
        }

        public void LaunchProcess()
        {
            ExecuteAsAdmin(processName);
        }

        private void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        public void WaitForClose()
        {
            bool foundProcess = false;

            while (!foundProcess)
            {
                var procInstances = Process.GetProcessesByName(processName);
                if (procInstances.Count() > 0)
                {
                    var proc = procInstances[0];
                    foundProcess = true;
                    proc.EnableRaisingEvents = true;
                    proc.WaitForExit();
                }
            }
        }

        public void WatchForClose()
        {
            bool foundProcess = false;

            while (!foundProcess)
            {
                var procInstances = Process.GetProcessesByName(processName);
                if (procInstances.Count() > 0)
                {
                    var proc = procInstances[0];
                    foundProcess = true;
                    proc.EnableRaisingEvents = true;
                    proc.Exited += Proc_Exited;
                }
            }
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            ProcessEnded?.Invoke(this, new EventArgs());
        }
    }
}

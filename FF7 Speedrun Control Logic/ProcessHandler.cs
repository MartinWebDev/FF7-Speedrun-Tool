using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7_Speedrun_Control_Logic
{
    public class ProcessHandler
    {
        public delegate void OnAttachProcess(object sender, EventArgs args);
        public event OnAttachProcess AttachedProcess;

        public ProcessHandler(string processName)
        {

        }

        public void AttachToProcess()
        {
            AttachedProcess(this, new EventArgs() { });
        }
    }
}

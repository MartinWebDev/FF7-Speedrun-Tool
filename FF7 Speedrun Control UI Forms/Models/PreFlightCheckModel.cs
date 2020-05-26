using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FF7_Speedrun_Control_Logic.Repositories;

namespace FF7_Speedrun_Control_UI_Forms.Models
{
    public class PreflightCheckModel
    {
        public ConfigRepository config;
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        public PreflightCheckModel(ConfigRepository config)
        {
            this.config = config;
        }

        public PreflightCheckModel Run()
        {
            IsSuccess = true;
            LocateFPSFixConfig();
            LocateFPSFixExe();
            return this;
        }

        private void AddError(string error)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }

            Errors.Add(error);
            IsSuccess = false;
        }

        private void LocateFPSFixExe()
        {
            if (!File.Exists(config.Get("FPSFixConfigFile")))
            {
                AddError("FPSFix not found! Please check App.config!");
            }
        }

        private void LocateFPSFixConfig()
        {
            if (!File.Exists(config.Get("FPSFixConfigFile")))
            {
                AddError("FPSFix Config File not found! Please check App.config!");
            }
        }
    }
}

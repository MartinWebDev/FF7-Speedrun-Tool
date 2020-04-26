using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Collections.Specialized;

namespace FF7_Speedrun_Control_Logic
{
    public class ConfigManager
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}

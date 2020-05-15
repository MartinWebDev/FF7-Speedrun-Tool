using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FF7_Speedrun_Control_Logic.Repositories
{
    public class ConfigRepository
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}

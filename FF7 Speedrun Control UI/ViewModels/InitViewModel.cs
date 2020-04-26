using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FF7_Speedrun_Control_Logic;

namespace FF7_Speedrun_Control_UI.ViewModels
{
    public class InitViewModel : Screen
    {
        private ConfigManager config = new ConfigManager();

        public InitViewModel()
        {
            config.Get("SteamRegKeyRoot");
        }

        private string _initOutput = $"Tool started{Environment.NewLine}Locating Steam folder...{Environment.NewLine}Steam folder found!{Environment.NewLine}FF7 found.";
        public string InitOutput
        {
            get { return _initOutput; }
            set
            {
                _initOutput = value;
                NotifyOfPropertyChange(() => InitOutput);
            }
        }
    }
}

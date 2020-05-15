using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FF7_Speedrun_Control_UI.Models;
using FF7_Speedrun_Control_Logic;

namespace FF7_Speedrun_Control_UI.ViewModels
{
    public class ConfigViewModel : Screen
    {
        private FPSFixConfig fpsConfig;
        private ConfigManager config;

        public ConfigViewModel()
        {
            config = new ConfigManager();
            fpsConfig = new FPSFixConfig(config.Get("FPSFixConfigFile"), new HexConverter());
            fpsConfig.LoadFile();
            FrameLockValue = fpsConfig.frameRateValue;
        }

        private string _message = "";
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        private int _frameLockValue;
        public int FrameLockValue
        {
            get
            {
                return _frameLockValue;
            }
            set
            {
                _frameLockValue = value;
                SaveWarning = "Value will not be saved until after testing!";
                NotifyOfPropertyChange(() => FrameLockValue);
            }
        }

        private string _saveWarning = "";
        public string SaveWarning
        {
            get { return _saveWarning; }
            set
            {
                _saveWarning = value;
                NotifyOfPropertyChange(() => SaveWarning);
            }
        }

        public bool CanIncreaseFrameLock(int frameLockValue)
        {
            Message = "";
            if (frameLockValue < 255) return true;
            Message = "Value must be less than 255!";
            return false;
        }

        public bool CanDecreaseFrameLock(int frameLockValue)
        {
            Message = "";
            if (frameLockValue > 0) return true;
            Message = "Value must be above 0!";
            return false;
        }

        public void IncreaseFrameLock(int frameLockValue)
        {
            FrameLockValue += 1;
        }

        public void DecreaseFrameLock(int frameLockValue)
        {
            FrameLockValue -= 1;
        }

        public void TestValue()
        {
            // Save back to fpsfix config file
            fpsConfig.frameRateValue = FrameLockValue;
            fpsConfig.SaveFile();
            // Launch fpsfix
            // Tell user to run game and check average fps
        }
    }
}

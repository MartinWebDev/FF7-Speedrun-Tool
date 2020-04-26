using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FF7_Speedrun_Control_UI.Models;

namespace FF7_Speedrun_Control_UI.ViewModels
{
    public class ConfigViewModel : Screen
    {
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

        private int _frameLockValue = 192;
        public int FrameLockValue
        {
            get
            {
                return _frameLockValue;
            }
            set
            {
                _frameLockValue = value;
                NotifyOfPropertyChange(() => FrameLockValue);
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
    }
}

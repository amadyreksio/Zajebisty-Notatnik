using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajebisty_Notatnik
{
    public static class Utils
    {
        public enum Theme
        {
            Light=0,Dark=1
        }
        public static Theme AppTheme = Theme.Dark;
        public enum FindMode
        {
            Find=0,Replace=1
        }
        public static Form1 MainForm;
    }
}

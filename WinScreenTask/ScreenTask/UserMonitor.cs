using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenTask
{
    /// <summary>
    /// Class to filling datasource of ComboBox
    /// </summary>
    class UserMonitor
    {
        public string DeviceName { get; set; }
        public string DisplayValue { get; set; }

        public UserMonitor()
        {
            DeviceName = "";
            DisplayValue = "";
        }
    }
}

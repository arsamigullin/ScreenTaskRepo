using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFTaskScreen
{
    [DataContract]
    public class UserMonitor
    {
        [DataMember]
        public string DeviceName { get; set; }

        [DataMember]
        public string DisplayValue { get; set; }

        public UserMonitor()
        {
            DeviceName = "";
            DisplayValue = "";
        }
    }
}

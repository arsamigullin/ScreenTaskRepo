using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFTaskScreen
{
    [ServiceContract]
    public interface IScreenShotable
    {
        [OperationContract]
        void TakeScreenShot(string path, string monitor);

        [OperationContract]
        List<UserMonitor> GetMonitorsList();
    }
}

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
        string TakeScreenShot(string path, string monitor, string prevUniqueSessVa);

        [OperationContract]
        List<UserMonitor> GetMonitorsList();
    }
}

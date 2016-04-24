using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFTaskScreen;

namespace WCFTaskScreen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ServiceHost serviceHost = new
                ServiceHost(typeof (ScreenShot),

                    new Uri("http://localhost:8000/WCFTaskScreen"));

            serviceHost.AddServiceEndpoint(
                typeof (IScreenShotable),
                new BasicHttpBinding(),
                "");
            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите клавишу <ENTER>.\n\n");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}

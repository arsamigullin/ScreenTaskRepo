using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ScreenTask;
using WCFTaskScreen;
using WebScreenTask;

namespace WebApplication2
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public partial class Default : System.Web.UI.Page
    {
        public static int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            initializeMonitors();
        }

        [System.Web.Services.WebMethod]
        public static string TakeScreenshot(string uniqueSessionVal, string monitorName)
        {
            try
            {
                var path = HttpContext.Current.Request.PhysicalApplicationPath + @"Images\ScreenTask" + uniqueSessionVal +".jpeg";
                GlobalData.WCFClient.TakeScreenShot(path, monitorName);
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        // инициализация мониторов
        private  void initializeMonitors()
        {
            // Get all monitors 
            List<UserMonitor> monitorNames = GlobalData.WCFClient.GetMonitorsList();
            // Bindidng monitors to ComboBox
            dd_monitors.DataValueField  = "DisplayValue";
            dd_monitors.DataMember = "DeviceName";
            dd_monitors.DataSource = monitorNames;
            dd_monitors.DataBind();
        }

  
    }
}
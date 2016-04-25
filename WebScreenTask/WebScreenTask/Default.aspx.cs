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
using System.Web.Script.Services;
using Microsoft.Ajax.Utilities;
using ScreenTask;
using WCFTaskScreen;
using WebScreenTask;

namespace WebApplication2
{

    public partial class Default : System.Web.UI.Page
    {
        static string uniqSession = "uniqSession";

        protected void Page_Load(object sender, EventArgs e)
        {
            initializeMonitors();
        }

        [WebMethod(EnableSession = true)]
        public static string TakeScreenshot(string uniqueSessionVal, string monitorName)
        {

            try
            {
                List<string> uniqList= new List<string>();
                if (HttpContext.Current.Session[uniqSession] != null)
                {
                    uniqList= HttpContext.Current.Session[uniqSession] as List<string>;
                }
                string prev="";
                if (uniqList != null && uniqList.Count > 5)
                {
                    
                    prev = HttpContext.Current.Request.PhysicalApplicationPath + @"Images\ScreenTask" + uniqList[0] + ".jpeg";
                    uniqList.RemoveAt(0);
                }
                var pathCur = HttpContext.Current.Request.PhysicalApplicationPath + @"Images\ScreenTask" + uniqueSessionVal + ".jpeg";
                if (uniqList != null)
                {
                    uniqList.Add(uniqueSessionVal);
                    HttpContext.Current.Session[uniqSession] = uniqList;
                }
                    
                GlobalData.WCFClient.TakeScreenShot(pathCur, monitorName, prev);
   
                return uniqList[0];
            }
            catch (Exception ex)
            {
                return "";
            }
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
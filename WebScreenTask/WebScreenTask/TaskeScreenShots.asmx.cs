using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

namespace WebScreenTask
{
    /// <summary>
    /// Summary description for TaskeScreenShot
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TaskeScreenShots : System.Web.Services.WebService
    {

        [WebMethod]
        public static string[] TakeScreenshot(string[] prms)
        {
            // HttpRequest request= new HttpRequest()
            try
            {
                var path = HttpContext.Current.Request.PhysicalApplicationPath + @"Images\ScreenTask" + prms[0] + ".jpeg";

                Rectangle bounds = Screen.AllScreens.First(m => m.DeviceName.Equals(prms[1])).Bounds;

                //   File.AppendAllLines(@"C:\Users\ThreeA\Desktop\log.txt", new List<string> { path });
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    // File.Delete(path);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.X, 0), new Point(bounds.Y, 0), bounds.Size);
                    }
                    bitmap.Save(path, ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {

            }

            return new string[0];
        }
    }
}

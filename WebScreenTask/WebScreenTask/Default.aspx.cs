using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        public static int i;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static string TakeScreenshot()
        {
            try
            {
                // string nameSelectedMonitor = comboBox_Monitors.SelectedValue.ToString();
                Rectangle bounds = Screen.AllScreens.First().Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    File.Delete(@"C:\projects\git\ScreenTaskRepo\WebScreenTask\WebScreenTask\Images\ScreenTask.jpeg");
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.X, 0), new Point(bounds.Y, 0), bounds.Size);
                    }
                    bitmap.Save(@"C:\projects\git\ScreenTaskRepo\WebScreenTask\WebScreenTask\Images\ScreenTask.jpeg", ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                
            }
       
            return "";
        }
  
    }
}
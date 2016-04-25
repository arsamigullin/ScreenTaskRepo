using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFTaskScreen;

namespace WCFTaskScreen
{

    public class ScreenShot:IScreenShotable
    {

        
        public string TakeScreenShot(string pathCur, string monitor, string pathPrev)
        {
            try
            {
                Rectangle bounds = Screen.AllScreens.First(m=>m.DeviceName==monitor).Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                  //  File.Delete(path);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.X, 0), new Point(bounds.Y, 0), bounds.Size);
                    }
                    bitmap.SetResolution(800f, 600f);
                    bitmap.Save(pathCur, ImageFormat.Png);
                 
                }
                File.Delete(pathPrev);
            }
            catch (Exception ex)
            {

                //File.AppendAllLines(@"C:\Users\ThreeA\Desktop\log.txt", new List<string> { ex.Message });
            }
            return "";
        }

        public List<UserMonitor> GetMonitorsList()
        {
            // Get all monitors 
           return Screen.AllScreens
                .OrderByDescending(m => m.Primary)
                .Select(m => new UserMonitor
                {
                    DisplayValue = m.DeviceName,
                    DeviceName = m.DeviceName
                })
                .ToList();
        }
    }
}

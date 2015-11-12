using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASS.ScreenshotTaker
{
    public interface IScreenshotTaker
    {
        Bitmap TakeScreenshot();
    }
}
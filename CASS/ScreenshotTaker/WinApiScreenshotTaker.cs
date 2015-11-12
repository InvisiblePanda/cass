using CASS.Exceptions;
using CASS.WindowsApi;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CASS.ScreenshotTaker
{
    internal class WinApiScreenshotTaker : IScreenshotTaker
    {
        private IntPtr targetHandle;

        public WinApiScreenshotTaker(string targetWindowTitle)
        {
            targetHandle = WinApi.FindWindow(null, targetWindowTitle);
            if (targetHandle == IntPtr.Zero)
            {
                throw new TargetWindowNotFoundException();
            }
        }

        public Bitmap TakeScreenshot()
        {
            WinApi.RECT windowRect;
            WinApi.GetWindowRect(targetHandle, out windowRect);

            Bitmap bmp = new Bitmap(windowRect.Width, windowRect.Height, PixelFormat.Format32bppArgb);
            using (Graphics bmpGraphics = Graphics.FromImage(bmp))
            {
                IntPtr bmpHdc = bmpGraphics.GetHdc();
                WinApi.PrintWindow(targetHandle, bmpHdc, 0);
                bmpGraphics.ReleaseHdc();

                return bmp;
            }
        }
    }
}
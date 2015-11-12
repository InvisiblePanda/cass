using CASS.Exceptions;

namespace CASS.ScreenshotTaker
{
    public static class ScreenshotTakerFactory
    {
        public static IScreenshotTaker CreateScreenshotTaker(string targetWindowTitle)
        {
            try
            {
                return new WinApiScreenshotTaker(targetWindowTitle);
            }
            catch (TargetWindowNotFoundException)
            {
                return null;
            }
        }
    }
}
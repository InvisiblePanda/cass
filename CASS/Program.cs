using CASS.ScreenshotTaker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program takes a screenshot of the client area of an external window.");
            Console.WriteLine();

            IScreenshotTaker cass;
            do
            {
                Console.WriteLine("Enter the title of the target window:");
                string targetWindowTitle = Console.ReadLine();

                cass = ScreenshotTakerFactory.CreateScreenshotTaker(targetWindowTitle);
                if (cass == null)
                {
                    Console.WriteLine("Target window could not be found. Please try again.");
                }
            } while (cass == null);

            Console.Clear();
            Console.WriteLine("The target window was successfully located.");
            Console.WriteLine();
            Console.WriteLine("Please enter the name of the output file without the '.bmp':");
            string fileName = Console.ReadLine();
            fileName += ".bmp";
            string currentPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
            string fullTargetPath = currentPath + fileName;

            using (Bitmap screenshot = cass.TakeScreenshot())
            {
                screenshot.Save(fullTargetPath);
            }

            Console.WriteLine("Screenshot successfully saved.");
            Console.ReadKey();
        }
    }
}
using System;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace AutoWall
{
    class Program
    {
        static void Main(string[] args)
        {
            int ResX = 1920;
            int ResY = 1080;

            int DayOfYear = 0;
            while (true)
            {
                if (DayOfYear != DateTime.Now.DayOfYear - 1)
                {
                    DayOfYear = DateTime.Now.DayOfYear -1;
                    try
                    {
                        new WebClient().DownloadFile("http://map2.vis.earthdata.nasa.gov/imagegen/index.php?TIME="+DateTime.Now.Year+""+DayOfYear+"&extent=-5.8232421875,49.599609375,2.6142578125,54.345703125&epsg=4326&layers=MODIS_Terra_CorrectedReflectance_TrueColor,sedac_bound&format=image/jpeg&width="+ResX+"&height="+ResY, "./Today_" + DayOfYear + ".jpg");
                        Console.WriteLine("Got the file!");
                        Process process = new Process();
                        // Configure the process using the StartInfo properties.
                        process.StartInfo.FileName = Directory.GetCurrentDirectory() + "/WallpaperChanger.exe";
                        Console.WriteLine("Calling: {0}", Directory.GetCurrentDirectory() + "/WallpaperChanger.exe");
                        process.StartInfo.Arguments = Directory.GetCurrentDirectory() + "/Today_" + DayOfYear + ".jpg";
                        process.Start();
                        process.WaitForExit();// Waits here for the process to exit.
                    }
                    catch
                    {
                        // Well I tried.
                    }
                }
                Thread.Sleep(60 * 1000);
            }
        }
    }
}

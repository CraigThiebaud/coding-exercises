using NasaAPIService.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RoverPhotosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = System.IO.File.ReadAllLines(@"~\..\..\..\..\..\dates.txt");
            var roverService = new MarsRoverService();
            DirectoryInfo info = Directory.CreateDirectory("C:\\MarsPhotos");
            

            foreach (var line in lines)
            {
                try
                {
                    var result = roverService.GetRoverImagesByDate(line);
                    DownloadImages(result.Images);
                    Console.WriteLine($"Total images on {line}: {result.Images.Count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DownloadImages(List<string> imageUrls)
        {
            foreach (var url in imageUrls)
            {
                var webClient = new WebClient();
                webClient.DownloadFile(url, "C:\\MarsPhotos\\" + url.Split('/').Last());
            }
        }
    }
}

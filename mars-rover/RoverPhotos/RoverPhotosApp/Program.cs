using NasaAPIService.Services;
using System;


namespace RoverPhotosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var fileContent = System.IO.File.ReadAllText("~/dates.txt");
            var lines = System.IO.File.ReadAllLines(@"~\..\..\..\..\..\dates.txt");
            var roverService = new MarsRoverService();
            foreach(var line in lines)
            {
                roverService.GetRoverImagesByDate(line);
            }
            Console.WriteLine("here");
        }
    }
}

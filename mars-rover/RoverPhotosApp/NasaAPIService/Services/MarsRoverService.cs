using NasaAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaAPIService.Services
{
    public class MarsRoverService
    {
        public RoverImages GetRoverImagesByDate(string date)
        {
            var uriString = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=2015-6-3&api_key=kKh7bH8p42hBOtScs9upsNirlKGtRGQJ9LkDqz4m";
            RoverImages result;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(new Uri(uriString)).Result;
                result = new RoverImages()
                {
                    Images = new List<string>()
                };
            }
            return result;
        }
    }
}

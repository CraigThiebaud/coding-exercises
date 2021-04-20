using NasaAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace NasaAPIService.Services
{
    public class MarsRoverService
    {
        public RoverImages GetRoverImagesByDate(string date)
        {
            RoverImages result;
            string dateString;
            dateString = DateTime.Parse(date).ToString("yyyy-MM-dd");

            using (var client = new HttpClient())
            {
                var uriString = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={dateString}&api_key=kKh7bH8p42hBOtScs9upsNirlKGtRGQJ9LkDqz4m";
                var response = client.GetAsync(new Uri(uriString)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    JObject jResponse = JObject.Parse(responseString);
                    var jList = jResponse["photos"].ToList();

                    result = new RoverImages()
                    {
                        Images = new List<string>()
                    };

                    foreach (var photo in jList)
                    {
                        result.Images.Add(photo["img_src"].ToString());
                    }
                    return result;
                }
                else
                {
                    throw new Exception("NASA API call failed.");
                }
            }
        }
    }
}

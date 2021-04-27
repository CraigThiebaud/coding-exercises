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
    public class MarsRoverService : IMarsRoverService
    {
        public async Task<RoverImages> GetRoverImagesByDateAsync(string date)
        {
            RoverImages result;
            DateTime parsedDate;
            var isValid = DateTime.TryParse(date, out parsedDate);
            var dateString = isValid ? parsedDate.ToString("yyyy-MM-dd") : null;
            if (isValid)
            {
                using (var client = new HttpClient())
                {
                    var uriString = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={dateString}&api_key=kKh7bH8p42hBOtScs9upsNirlKGtRGQJ9LkDqz4m";
                    var response = await client.GetAsync(new Uri(uriString));

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
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
            else
            {
                throw new Exception("Date invalid.");
            }
            
        }
    }
}

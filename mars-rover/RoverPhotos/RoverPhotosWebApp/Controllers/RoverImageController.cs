using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NasaAPIService.Services;

namespace RoverPhotosWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverImageController : Controller
    {
        private IMarsRoverService roverService;

        public RoverImageController(IMarsRoverService service)
        {
            roverService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync(string date)
        {
            return (await roverService.GetRoverImagesByDateAsync(date)).Images;
        }
    }
}

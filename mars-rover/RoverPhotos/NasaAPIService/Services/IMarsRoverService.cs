using NasaAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaAPIService.Services
{
    public interface IMarsRoverService
    {
        public RoverImages GetRoverImagesByDate(string date);
    }
}

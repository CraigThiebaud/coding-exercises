using Moq;
using NasaAPIService.Services;
using NUnit.Framework;
using RoverPhotosWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Tests.Controllers
{
    public class On_The_Rover_Image_Controller
    {
        protected Mock<IMarsRoverService> service;
        protected RoverImageController controller;

        [SetUp]
        protected virtual void SetUp()
        {
            service = new Mock<IMarsRoverService>();
        }
    }
}

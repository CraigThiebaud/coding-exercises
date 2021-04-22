﻿using Moq;
using NasaAPIService.Models;
using NUnit.Framework;
using RoverPhotosWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Tests.Controllers
{
    public class When_Getting_Rover_Images : On_The_Rover_Image_Controller
    {
        private List<string> result;
        private string expectedResult = "http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/01004/opgs/edr/rcam/RRB_486615482EDR_F0481570RHAZ00323M_.JPG";

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();

            service.Setup(x => x.GetRoverImagesByDate(It.IsAny<string>())).Returns(new RoverImages() 
            {
                Images = new List<string>() { expectedResult }
            });

            controller = new RoverImageController(service.Object);
        }

        void Because(string date)
        {
            result = controller.Get("test").ToList();
        }

        [Test]
        public void Should_return_list_of_strings()
        {
            Because("test");
            Assert.IsInstanceOf<List<string>>(result);
        }

        [Test]
        public void Should_return_expected_result()
        {
            Because("test");
            Assert.AreEqual(expectedResult, result.First());
        }
    }
}
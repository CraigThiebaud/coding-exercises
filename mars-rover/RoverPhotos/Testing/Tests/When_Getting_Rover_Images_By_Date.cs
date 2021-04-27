using NasaAPIService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Testing.Tests
{
    public class When_Getting_Rover_Images_By_Date : On_The_Mars_Rover_Service
    {
        private RoverImages result;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
        }

        public async Task BecauseAsync(string date)
        {
            result =  await service.GetRoverImagesByDateAsync(date);
        }

        [Test]
        public async Task Should_Return_Rover_Images_Model_Async()
        {
            await BecauseAsync("Jul-13-2016");
            Assert.IsInstanceOf<RoverImages>(result);
        }

        [Test]
        public async Task Should_Return_Expected_Results_Async()
        {
            await BecauseAsync("2015-6-3");
            Assert.AreEqual(4, result.Images.Count);
            Assert.AreEqual("http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/01004/opgs/edr/fcam/FLB_486615455EDR_F0481570FHAZ00323M_.JPG", result.Images.First().ToString());
        }
    }
}

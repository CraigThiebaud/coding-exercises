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

        }

        public void Because(string date)
        {
            result =  service.GetRoverImagesByDate(date);
        }

        [Test]
        public void Should_Return_Rover_Images_Model()
        {
            Because("");
            Assert.IsInstanceOf<RoverImages>(result);
        }
    }
}

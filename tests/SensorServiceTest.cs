using System;
using NUnit.Framework;
using SensorApi.Services;

namespace SensorApi.UnitTests.Services
{
    [TestFixture]
    public class SensorService_Tests
    {
        [Test]
        public void IsCollectionList_Of_ModelsSensor()
        {
            SensorService sensorService = CreateSensorService();
            var result = sensorService.GetSensor();

            Assert.That(result, Is.InstanceOf<System.Collections.Generic.List<Models.Sensor>>());
        }

        private SensorService CreateSensorService()
        {
            return new SensorService();
        }

        /*
        More tests
        */

        
    }
}
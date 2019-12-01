using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using SensorApi.Models;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {

        // GET api/sensor
        [HttpGet]
        // public ActionResult<IEnumerable<Sensor>> Get()
        public ActionResult<System.Collections.Generic.List<Sensor>> GetAction()
        {
            var sensorService = new SensorApi.Services.SensorService();

            return sensorService.GetSensor();
        }

        // GET api/sensor/aggregation
        // [HttpGet("/aggregation")]
        // public ActionResult<string> GetAggregation()
        // {
        //     return "value";
        // }

        // POST api/sensor
        [HttpPost]
        public void Post([FromBody]Sensor sensor)
        {
            var sensorService = new SensorApi.Services.SensorService();
            Task task = sensorService.SaveSensor(sensor);
        }
    }
}

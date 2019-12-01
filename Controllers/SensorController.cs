using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET api/sensor/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/sensor
        [HttpPost]
        public void Post([FromBody]Sensor sensor)
        {
            var sensorService = new SensorApi.Services.SensorService();
            Task task = sensorService.SaveSensor(sensor);


            // await _elasticClient.IndexDocumentAsync(post);
        }

        // PUT api/sensor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/sensor/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

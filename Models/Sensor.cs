using System;
using System.Collections.Generic;

namespace SensorApi.Models
{
    public class Sensor
    {
        public double timestamp { get; set; }
        public string tag { get; set; }
        public string value { get; set; }
    }

    public class SensorAggregation
    {
        public string tag { get; set; }
        public long? count { get; set; }

        public SensorAggregation(string key, long? docCount)
        {
            this.tag = key;
            this.count = docCount;
        }
    }
}
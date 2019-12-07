using System;
using System.Collections.Generic;

namespace SensorApi.Models
{
    public class Sensor
    {
        public int timestamp { get; set; }
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

            Console.WriteLine(key);
            Console.WriteLine(docCount);
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using SensorApi.Models;

namespace SensorApi.Services
{
    public class SensorService
    {
        private IElasticClient elasticClient;

        public SensorService()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("sensor")
                .DefaultMappingFor<Sensor>(m => m
                    .PropertyName(p => p.timestamp, "timestamp")
                );

            elasticClient = new ElasticClient(settings);
            elasticClient.Indices.Create("sensor");
        }

        public System.Collections.Generic.List<Sensor> GetSensor()
        {
            var searchResponse = elasticClient.Search<Sensor>(s => s.From(0).Size(10));
            var sensors = searchResponse.Documents;

            return sensors.ToList();
        }

        public async Task SaveSensor(Sensor sensor)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("sensor")
                .DefaultMappingFor<Sensor>(m => m
                    .PropertyName(p => p.timestamp, "timestamp")
                );
            
            await elasticClient.IndexDocumentAsync(sensor);
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using SensorApi.Models;

namespace SensorApi.Services
{
    public class SensorService
    {
        // private readonly IElasticClient _elasticClient;

        // public SensorService(IElasticClient elasticClient)
        // {
        //     _elasticClient = elasticClient
        // }

        public System.Collections.Generic.List<Sensor> GetSensor()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("sensor")
                .DefaultMappingFor<Sensor>(m => m
                    .PropertyName(p => p.timestamp, "timestamp")
                );

            var client = new ElasticClient(settings);
            var searchResponse = client.Search<Sensor>(s => s.From(0).Size(10));
            var sensors = searchResponse.Documents;

            Console.WriteLine(sensors.Count);

            foreach(Sensor sensor in sensors)
            {
                Console.WriteLine(sensor.tag);
            }

            return sensors.ToList();
            // sensors.stream()
            
            // return await client.GetManyAsync();
        }

        public async Task SaveSensor(Sensor sensor)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("sensor")
                .DefaultMappingFor<Sensor>(m => m
                    .PropertyName(p => p.timestamp, "timestamp")
                );

            var client = new ElasticClient(settings);
            // var indice = client.Indices.Get("sensor");
            // client.Indices.Create("sensor");
            
            await client.IndexDocumentAsync(sensor);
            

            // var service = (IElasticClient)ServiceProvider.GetService(typeof(IElasticClient))
            // var sp = services.BuildServiceProvider();

            // ServiceProvider.GetService(IElasticClient _elasticsearchClient)
            // await _elasticClient.IndexDocumentAsync(sensor);
            Console.WriteLine(sensor.tag);
        }
    }
}
using System;
using System.Collections.Generic;
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
                    .PropertyName(p => p.tag, "tag")
                    .PropertyName(p => p.timestamp, "timestamp")
                );

            elasticClient = new ElasticClient(settings);
            elasticClient.Indices.Create("sensor", i => i
                .Map<Sensor>(m => m
                    .Properties(ps => ps
                        .Keyword(k => k
                            .Name(n => n.tag)
                        )
                    )
                )
            );
        }

        public System.Collections.Generic.List<Sensor> GetSensor()
        {
            var searchResponse = elasticClient.Search<Sensor>(s => s
                .From(0)
                .Size(10)
                .Sort(sort => sort
                    .Descending(p => p.timestamp)
                )
            );
            var sensors = searchResponse.Documents;

            return sensors.ToList();
        }

        public System.Collections.Generic.List<SensorAggregation> GetSensorAggregation()
        {
            var search = new SearchDescriptor<Sensor>()
                .Aggregations(ag => ag
                    .Terms("tags", term => term
                        .Field(field => "tag.keyword")));

            var searchResponse = elasticClient.Search<Sensor>(q => q
                .Size(0)
                .Aggregations(agg => agg.Terms(
                    "tags", e => 
                        e.Field("tag.keyword")
                )));

            var results = searchResponse
                .Aggregations
                .Terms("tags")
                .Buckets
                .ToList();

            var response = new System.Collections.Generic.List<SensorAggregation>();
            foreach(var item in results) {
                response.Add(new SensorAggregation(item.Key, item.DocCount));
            }

            return response;
        }

        public async Task SaveSensor(Sensor sensor)
        {
            await elasticClient.IndexDocumentAsync(sensor);
        }
    }
}
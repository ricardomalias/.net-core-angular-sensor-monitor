using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using SensorApi.Models;

public static class ElasticsearchExtensions
{
    public static void AddElasticsearch(
        this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["elasticsearch:url"];
        var defaultIndex = configuration["elasticsearch:index"];

        var settings = new ConnectionSettings(new Uri(url))
            .DefaultIndex(defaultIndex)
            .DefaultMappingFor<Sensor>(m => m
                .PropertyName(p => p.timestamp, "timestamp")
            );

        var client = new ElasticClient(settings);

        services.AddSingleton<IElasticClient>(client);
    }
}
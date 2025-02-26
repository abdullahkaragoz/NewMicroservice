﻿using MongoDB.Driver;
using NewMicroservice.Catalog.Api.Options;

namespace NewMicroservice.Catalog.Api.Repositories;
public static class RepositoryExt
{
    public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient, MongoClient>(sp =>
         {
             var options = sp.GetRequiredService<MongoOption>();
             return new MongoClient(options.ConnectionString);
         });

        services.AddScoped(sp =>
        {
            var options = sp.GetRequiredService<MongoOption>();
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
        });

        return services;
    }
}

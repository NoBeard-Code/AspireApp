var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var rabbit = builder.AddRabbitMQ("rabbit");

var apiService = builder.AddProject<Projects.AspireApp_ApiService>("apiservice")
    .WithReference(rabbit);

builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.NetworkMonitor_ApiService>("apiservice");

builder.AddProject<Projects.NetworkMonitor_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MogulyServer_Api>("moguly-api")
    .WithExternalHttpEndpoints();

builder.Build().Run();
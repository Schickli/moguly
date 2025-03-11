var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MogulyServer_Signal>("moguly-signal").WithExternalHttpEndpoints();

builder.Build().Run();
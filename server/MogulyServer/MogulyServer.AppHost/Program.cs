var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MogulyServer_Signal>("moguly-signal");

builder.Build().Run();
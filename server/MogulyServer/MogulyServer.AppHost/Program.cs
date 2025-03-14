var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("database");

var signalService = builder.AddProject<Projects.MogulyServer_Signal>("moguly-signal")
    .WithExternalHttpEndpoints()
    .WithReference(db)
       .WaitFor(db);

builder.AddProject<Projects.MogulyServer_MigrationService>("migrations")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
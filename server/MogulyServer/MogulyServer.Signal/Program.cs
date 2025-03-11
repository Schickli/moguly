using MogulyServer.Signal.Feature.Moguly;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSignalR();
    //.AddNamedAzureSignalR("moguly-signalR");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.MapHub<MogulyHub>("/moguly-hub");

app.UseRouting();
app.UseWebSockets();

app.UseCors();
app.Run();

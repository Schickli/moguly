using Microsoft.Extensions.Options;
using MogulyServer.Signal;
using MogulyServer.Signal.Hub.Moguly;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
})
    .AddNewtonsoftJsonProtocol();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddSingleton<CommandTypeResolver>();

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

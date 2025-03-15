using MogulyServer.Persistence.Board;
using MogulyServer.Persistence.Context;
using MogulyServer.Persistence.Player;

namespace MogulyServer.Signal
{
    public static class DependencyInjection
    {
        public static void AddMogulyServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<BoardRepository>();
            services.AddScoped<PlayerRepository>();
        }
    }
}

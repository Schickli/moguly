using MogulyServer.Persistence.Context;

namespace MogulyServer.Signal
{
    public static class DependencyInjection
    {
        public static void AddMogulyServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

using Warships.common.Interfaces.Services;
using Warships.common.Services;
using Warships.common.Utility;

namespace Warships.Extentions;

public static class ServiceCollectionExtentions
{
    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IGameService, GameService>();
        serviceCollection.AddSingleton<IPlayerService, PlayerService>();
        serviceCollection.AddTransient<ILogger, WarShipLogger>();
        serviceCollection.AddMemoryCache();
    }
    
}
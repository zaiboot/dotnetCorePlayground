namespace Api.Infra;
using System.Collections.Concurrent;
public static class Dependencies
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddSingleton<ConcurrentQueue<int>>();
    }
}
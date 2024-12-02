using Application.SPG.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Spotify.SPG
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSpotifyIntegrationSPG(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ISpotifyClient, SpotifyClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.spotify.com/v1");
            });

            return services;
        }
    }
}

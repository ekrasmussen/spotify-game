using Core.Entities;

namespace Application.SPG.Common.Interfaces
{
    public interface IMasterCache
    {
        SpotifyAccessToken? GetSpotifyAccessToken();
        void SetSpotifyAccessToken(SpotifyAccessToken token);
    }
}

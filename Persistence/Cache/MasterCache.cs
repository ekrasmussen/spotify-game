using Application.SPG.Common.Interfaces;
using Core.Entities;

namespace Persistence.Cache
{
    public class MasterCache : IMasterCache
    {
        public SpotifyAccessToken? SpotifyAccessToken { get; set; }

        public SpotifyAccessToken? GetSpotifyAccessToken()
        {
            return SpotifyAccessToken;
        }
        
        public void SetSpotifyAccessToken(SpotifyAccessToken token)
        {
            SpotifyAccessToken = token;
        }
    }
}

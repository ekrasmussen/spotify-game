using Spotify.SPG.Responses;

namespace Application.SPG.Interfaces
{
    public interface ISpotifyClient
    {
        Task<PlaylistsByUserIdResponse> GetPlaylists(string userId);
        Task RefreshAccessToken();
        Task TestAccessToken();
    }
}

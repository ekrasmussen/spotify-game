using Core.Entities;
using Spotify.SPG.Responses;

namespace Application.SPG.Interfaces
{
    public interface ISpotifyClient
    {
        Task<List<Playlist>> GetPlaylists(string userId);
        Task RefreshAccessToken();
        Task TestAccessToken();
        Task<List<Track>> GetTracksFromPlaylist(string playlistId);
    }
}

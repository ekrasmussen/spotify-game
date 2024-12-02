using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.SPG.Interfaces
{
    public interface ISpotifyClient
    {
        Task<List<Track>> GetTracks(string playlistId);
        Task RefreshAccessToken();
        Task TestAccessToken();
    }
}

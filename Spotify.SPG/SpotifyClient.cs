using Application.SPG.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.SPG
{
    public class SpotifyClient : ISpotifyClient
    {
        private readonly IHttpClientHandler _clientHandler;

        public SpotifyClient(HttpClient client)
        {
            _clientHandler = new HttpClientHandler(client);    
        }

        public Task<List<Track>> GetTracks(string playlistId)
        {
            throw new NotImplementedException();
        }

        public string RunTest(string testText)
        {
            return testText + " - OK!";
        }
    }
}

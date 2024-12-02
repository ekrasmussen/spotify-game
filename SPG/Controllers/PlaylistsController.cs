using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SPG.Controllers
{
    public class PlaylistsController : ControllerBase<PlaylistsController>
    {
        [HttpGet]
        public async Task<bool> GetPlaylistsFromId(string id)
        {
            return true;
        }
    }
}

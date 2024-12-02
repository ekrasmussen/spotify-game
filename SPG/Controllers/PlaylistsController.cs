using Application.SPG.UseCases.Playlists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SPG.Controllers
{
    public class PlaylistsController : ControllerBase<PlaylistsController>
    {
        [HttpGet]
        [Route("{id:string}")]
        public async Task<Unit> MirrorPlaylistsFromUserId(string id)
        {
            return await Mediator.Send(new MirrorPlaylistsFromUserIdCommand() { Id = id });
        }
    }
}

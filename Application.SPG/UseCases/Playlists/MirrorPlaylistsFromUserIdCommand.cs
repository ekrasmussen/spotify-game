using Application.SPG.Interfaces;
using Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SPG.UseCases.Playlists
{
    public class MirrorPlaylistsFromUserIdCommand : IRequest<Unit>
    {
        public string Id { get; set; } = string.Empty;

        public class MirrorPlaylistsFromUserIdCommandHandler(ISPGContext context, ISpotifyClient client) : IRequestHandler<MirrorPlaylistsFromUserIdCommand, Unit>
        {
            public async Task<Unit> Handle(MirrorPlaylistsFromUserIdCommand command, CancellationToken cancellationToken)
            {
                return Unit.Value;
            }
        }
    }
}

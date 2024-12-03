using Application.SPG.Interfaces;
using Application.SPG.Utils;
using Core.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SPG.UseCases.Playlists
{
    public class MirrorPlaylistsFromUserIdCommand : IRequest<Unit>
    {
        public string Id { get; set; } = string.Empty;

        public class MirrorPlaylistsFromUserIdCommandHandler(ISPGContext context, ISpotifyClient client) : IRequestHandler<MirrorPlaylistsFromUserIdCommand, Unit>
        {
            public async Task<Unit> Handle(MirrorPlaylistsFromUserIdCommand command, CancellationToken cancellationToken)
            {
                List<Track> tracks = [];
                List<UserTrack> userTrack = [];

                var playlistsResponse = await client.GetPlaylists(command.Id);

                foreach(var playlist in playlistsResponse)
                {
                    var result = await client.GetTracksFromPlaylist(playlist.ExternalId);

                    foreach(var track in result)
                    {
                        tracks.Add(track);
                    }
                }

                var user = context.UserUpdate.FirstOrDefault(x => x.ExternalId == command.Id);

                if(user != null)
                {
                    user.LastUpdated = DateTime.UtcNow;
                    await context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    var userupdate = new UserUpdate
                    {
                        ExternalId = command.Id,
                        LastUpdated = DateTime.UtcNow,
                    };

                    context.UserUpdate.Add(userupdate);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var existingExternalIds = await context.Tracks
                                        .Select(e => e.ExternalId)
                                        .ToListAsync();

                var newTracks = tracks.Where(e => !existingExternalIds.Contains(e.ExternalId)).ToList();

                if(newTracks.Count > 0)
                {
                    context.Tracks.AddRange(newTracks);
                }

                await context.SaveChangesAsync(cancellationToken);


                //Update User Tracks
                foreach(var track in tracks)
                {
                    var trackHash = HashUtil.HashWithSHA256(track.Title + track.ArtistsWashed);
                    var originalTrack = context.Tracks.FirstOrDefault(t => t.ExternalId == track.ExternalId);

                    userTrack.Add(new UserTrack
                    {
                        ExternalUserId = command.Id,
                        TrackHash = trackHash,
                        TrackId = originalTrack!.Id,
                        Track = originalTrack
                    });
                }

                var existingUserTracks = await context.UserTracks
                    .Where(x => x.ExternalUserId == command.Id)
                    .ToListAsync();

                // Filter the new tracks, excluding those already in the database
                var newUserTracks = userTrack
                    .Where(e => !existingUserTracks.Any(existing =>
                        existing.ExternalUserId == e.ExternalUserId &&
                        existing.TrackHash == e.TrackHash))
                    .ToList();

                // Add only the new tracks to the database
                if (newUserTracks.Any())
                {
                    context.UserTracks.AddRange(newUserTracks);
                    await context.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserTrack
    {
        public int Id { get; set; }
        public string ExternalUserId { get; set; } = string.Empty;
        public int TrackId { get; set; }
        public required Track Track { get; set; }
        public string TrackHash { get; set; } = string.Empty;
    }
}

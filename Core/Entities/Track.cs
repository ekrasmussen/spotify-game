using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string ExternalId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string AlbumName { get; set; } = string.Empty;
        public string ArtistsWashed { get; set; } = string.Empty;
        public bool IsExplicit { get; set; }
        public DateTimeOffset AddedOn { get; set; }
    }
}

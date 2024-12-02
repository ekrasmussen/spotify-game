using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public string ExternalId { get; set; } = string.Empty;
        public DateTimeOffset? LastUpdated { get; set; }
    }
}

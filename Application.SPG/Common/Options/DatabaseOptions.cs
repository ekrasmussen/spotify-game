using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SPG.Common.Options
{
    public class DatabaseOptions
    {
        public const string SECTION = "DatabaseOptions";
        public bool ApplyMigration { get; set; }
    }
}

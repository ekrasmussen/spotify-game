using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Options
{
    public class FeatureFlagOptions
    {
        public const string SECTION = "FeatureFlagOptions";
        public bool SelectedNamesOnly { get; set; }

        public List<string> AllowedNames { get; set; } = [];
    }
}

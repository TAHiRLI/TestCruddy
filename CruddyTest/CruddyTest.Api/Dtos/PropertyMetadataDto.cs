using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruddyTest.Dtos
{
    public class PropertyMetadataDto
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string DisplayName { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public string HelpText { get; set; } = string.Empty;

        // Validation
        public bool IsRequired { get; set; }
        public string? RequiredMessage { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }

    }
}
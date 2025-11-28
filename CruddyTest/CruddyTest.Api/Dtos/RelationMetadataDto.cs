using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruddyTest.Api.Dtos
{
    public class RelationMetadataDto
    {
        public required string Name { get; set; }
        public required string TargetEntity { get; set; }
        public required string Type { get; set; }
        public bool IsRequired { get; set; }
        public string? ForeignKey { get; set; }
    }
}
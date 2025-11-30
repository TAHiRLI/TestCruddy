using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cruddy.Core.Models;

namespace CruddyTest.Dtos
{
    public class EntityMetadataDto
    {
        public string Name { get; set; } = "";
        public string ClrType { get; set; } = "";
        public IEnumerable<PropertyMetadataDto> Properties { get; set; } = new List<PropertyMetadataDto>();
        public IEnumerable<RelationshipMetadata> Relations { get; set; } = new List<RelationshipMetadata>();


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruddyTest.Api.Dtos;

namespace CruddyTest.Dtos
{
    public class EntityMetadataDto
    {
        public string Name { get; set; } = "";
        public string ClrType { get; set; } = "";
        public IEnumerable<PropertyMetadataDto> Properties { get; set; } = new List<PropertyMetadataDto>();
        public IEnumerable<RelationMetadataDto> Relations { get; set; } = new List<RelationMetadataDto>();


    }
}
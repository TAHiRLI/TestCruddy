using Cruddy.Core.Attributes;

namespace CruddyTest.Core.Entities
{
    [Entity(typeof(Department))]
    public class Department
    {
        public string? Name { get; set; }
        public int Age { get; set; }

        public ICollection<Employee> Employees { get; set; } = []; 
    }
}
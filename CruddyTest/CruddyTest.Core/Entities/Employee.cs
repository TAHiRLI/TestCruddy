using Cruddy.Core.Attributes;

namespace CruddyTest.Core.Entities
{
    [Entity(typeof(Employee))]
    public class Employee
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
    }
}
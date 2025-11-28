// CruddyTest.Core/Cruddy/EmployeeCruddyConfig.cs
using Cruddy.Core.Configuration;
using CruddyTest.Core.Entities;

namespace CruddyTest.Core.Cruddy;

public class EmployeeCruddyConfig : CruddyEntityConfig<Employee>
{
    public EmployeeCruddyConfig()
    {
        ForEntity()
            .HasRelation("Relation")
            .HasDisplayName("Employee")
            .HasPluralName("Employees");

        ForProperty(x => x.Name)
            .HasDisplayName("The name of the employee 1").HasFieldType("string")
            .HasMinLength(12)
            .HasMaxLength(200)
            .HasPlaceholder("Enter employee name placeholder")
            .IsRequired()
            .ShowInList()
            .ShowInForm().IsRequired("This is a custom required filed");

        ForProperty(x => x.Email)
            .HasFieldType("email")
            .IsRequired();
    }
}
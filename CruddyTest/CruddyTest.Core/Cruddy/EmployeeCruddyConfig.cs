// CruddyTest.Core/Cruddy/EmployeeCruddyConfig.cs
using Cruddy.Core.Configuration;
using CruddyTest.Core.Entities;

namespace CruddyTest.Core.Cruddy;

public class EmployeeCruddyConfig : CruddyEntityConfig<Employee>
{
    public EmployeeCruddyConfig()
    {
        ForEntity()
            .HasOne(x => x.Department)
            .WithForeignKey(x => x.DepartmentId)
            .WithInverse(x => x.Department.Employees)
            .HasDisplayName("The department of the employee"); 

        ForProperty(x => x.Name)
            .HasDisplayName("The name of the employee 1").HasFieldType("string")
            .HasMinLength(11)
            .HasMaxLength(110)
            .HasPlaceholder("Enter employee name placeholder")
            .IsRequired()
            .ShowInList()
            .ShowInForm().IsRequired("This is a custom required filed");

        ForProperty(x => x.Email)
            .HasFieldType("email")
            .IsRequired();
    }
}
namespace ConsoleApplication
{
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;
	//using MySql.Data;
	using MySql.Data.EntityFrameworkCore.Extensions;

/// <summary>
/// The entity framework context with a Employees DbSet
/// </summary>
public class EmployeesContext : DbContext
{
public EmployeesContext(DbContextOptions<EmployeesContext> options)
: base(options)
{ }

public DbSet<Employee> Employees { get; set; }
}

/// <summary>
/// Factory class for EmployeesContext
/// </summary>
public static class EmployeesContextFactory
{
public static EmployeesContext Create(string connectionString)
{
var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
optionsBuilder.UseMySQL(connectionString);

//Ensure database creation
var context = new EmployeesContext(optionsBuilder.Options);
context.Database.EnsureCreated();

return context;
}
}

/// <summary>
/// A basic class for an Employee
/// </summary>
public class Employee
{
public Employee()
{
}

public int Id { get; set; }

[MaxLength(30)]
public string Name { get; set; }

[MaxLength(50)]
public string LastName { get; set; }
}
}
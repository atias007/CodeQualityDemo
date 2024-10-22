using System.ComponentModel.DataAnnotations.Schema;

namespace SqliteDemo;

[Table("Person")]
public class Person
{
    public int Id { get; set; } // Primary Key
    public string Name { get; set; } = null!;
}
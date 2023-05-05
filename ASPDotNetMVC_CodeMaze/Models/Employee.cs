namespace ASPDotNetMVC_CodeMaze.Models;

public class Employee
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public double Salary { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nationlity { get; set; } = null!;

    [Required]
    public bool IsPromoted { get; set; }

    [NotMapped]
    public int DisplayIndex { get; set; }
}
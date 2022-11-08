using System.ComponentModel.DataAnnotations;

namespace MvcLabManager.Models;

public class Computer
{
    [Required]
    [Range(0, 999)]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string Ram { get; set; }

    [Required]
    [StringLength(10)]
    public string Processor { get; set; }

    public Computer() { }

    public Computer(int id, string ram, string processor)
    {
        Id = id;
        Ram = ram;
        Processor = processor;
    }
}
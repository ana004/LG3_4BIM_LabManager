using System.ComponentModel.DataAnnotations;

namespace MvcLabManager.Models;

public class Lab
{
    [Required]
    [Range(0, 999)]
    public int Id { get; set; }

    [Required]
    [Range(1, 300)]
    public int Number { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 7)]
    public string Name { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 7)]
    public string Block { get; set; }

    public Lab() { }

    public Lab(int id, int number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}
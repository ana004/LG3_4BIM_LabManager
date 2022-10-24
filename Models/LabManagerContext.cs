using Microsoft.EntityFrameworkCore;

namespace MvcLabManager.Models;

public class LabManagerContext : DbContext
{
    //DbSet para Computer, Lab, etc

    public DbSet<Computer> Computers { get; set; }

    public DbSet<Lab> Labs { get; set; }

    public LabManagerContext(DbContextOptions<LabManagerContext> options) : base(options)
    //base é construtor da classe DbContextOptions. Igual a classe super do Java
    {

    }
}
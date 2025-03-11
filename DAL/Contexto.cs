using Angel_Paredes_P2_AP1.Components.Models;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Detalle> Detalles { get; set; }
    public DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>()
            .HasMany(c => c.Detalles)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
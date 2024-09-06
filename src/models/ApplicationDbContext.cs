using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

  public DbSet<Mecanico> Mecanicos { get; set; }
  public DbSet<TipoConserto> TipoConserto { get; set; }
  public DbSet<ConsertoDeMotos> ConsertoDeMotos { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ConsertoDeMotos>()
      .HasKey(c => new { c.MotoId, c.DataEntrada, c.TipoConsertoId });
  }
}
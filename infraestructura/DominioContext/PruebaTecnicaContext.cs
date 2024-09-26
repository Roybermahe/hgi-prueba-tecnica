using Dominio.Negocio.Usuarios;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.DominioContext;

public class PruebaTecnicaContext: DomainContextBase
{
    public PruebaTecnicaContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Identificacion)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreatedAt") != null))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Property("CreatedAt").IsModified = false;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            entry.Property("UpdateAt").CurrentValue = DateTime.UtcNow;
        }
        return base.SaveChanges();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Infraestructura.Base;
public interface IDbContext
{
    DbSet<T> Set<T>() where T : class;
    EntityEntry Entry(object entity);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    void SetModified(object entity);
    int SaveChanges();
}
    
public class DomainContextBase : DbContext, IDbContext
{
    public DomainContextBase(DbContextOptions options) : base(options)
    {
    }

    public void SetModified(object entity)
    {
        Entry(entity).State = EntityState.Modified;
    }
}
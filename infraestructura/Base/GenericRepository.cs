using System.Linq.Expressions;
using Dominio.Base;
using Dominio.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Base;

public abstract class GenericRepository<T>: IGenericRepository<T> where T: BaseEntity
{
    protected IDbContext dbContext;
    protected readonly DbSet<T> dbSet;

    protected GenericRepository(IDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<T>();
    }
    
    public T Find(int id)
    {
        return dbSet.Find(id)!;
    }

    public T Add(T entity)
    {
        var add = dbSet.Add(entity);
        return add.Entity;
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public T Edit(T entity)
    {
        var update = dbSet.Update(entity);
        
        return update.Entity;
    }

    public void AddRange(List<T> entities)
    {
        dbSet.AddRange(entities);
    }

    public void DeleteRange(List<T> entities)
    {
        dbSet.RemoveRange(entities);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return dbSet.AsEnumerable();
    }

    public T FindFirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return dbSet.FirstOrDefault(predicate)!;
    }
}
using System.Linq.Expressions;
using Dominio.Base;

namespace Dominio.Contratos;

public interface IGenericRepository<T> where T: BaseEntity
{
    T Find(int id);
    T Add(T entity);
    void Delete(T entity);
    T Edit(T entity);
    void AddRange(List<T> entities);
    void DeleteRange(List<T> entities);
    IEnumerable<T> GetAll();
    T FindFirstOrDefault(Expression<Func<T, bool>> predicate);
}
namespace Dominio.Base;

public abstract class BaseEntity
{
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;  
}
    
public abstract class Entity<T> : BaseEntity, IEntity<T>
{
    public virtual T Id { get; set; }
}
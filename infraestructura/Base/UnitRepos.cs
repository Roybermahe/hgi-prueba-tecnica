using dominio.Repositorios;
using Infraestructura.Repositorios;

namespace Infraestructura.Base;

public abstract class UnitRepos(IDbContext context) : IUnitRepos
{
    protected IDbContext dbContext;
 
    private IUsuarioRepository _usuarioRepository;
    public IUsuarioRepository UsuarioRepository
    {
        get { return _usuarioRepository ??= new UsuarioRepository(dbContext); }
    }
}
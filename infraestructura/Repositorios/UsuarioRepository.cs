using Dominio.Negocio.Usuarios;
using dominio.Repositorios;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios;
public class UsuarioRepository: GenericRepository<Usuario>, IUsuarioRepository
{
    private IUsuarioRepository _usuarioRepositoryImplementation;

    public UsuarioRepository(IDbContext contexto) : base(contexto) 
    { }

    public List<Usuario> ObtenerUsuariosPaginados(int pageSize, int page, string? key  = "")
    {
        try
        {
            var skip = (pageSize - 1) * page;
            var terms = key?.Split(" ").Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
            IQueryable<Usuario> query = dbContext.Set<Usuario>();

            if (terms != null)
                query = terms.Aggregate(query,
                    (current, term) => current.Where(u =>
                        EF.Functions.ILike(u.Nombre, $"%{term}%") || EF.Functions.ILike(u.Apellido, $"%{term}%")));
            return query
                .OrderBy(usuario => usuario.Id)
                .Skip(skip)
                .Take(page)
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
using dominio.Repositorios;

namespace Dominio.Contratos;

public interface IUnitOfWork: IDisposable, IUnitRepos
{
    string Commit();
}
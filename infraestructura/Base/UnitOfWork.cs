using System.Data.Common;
using Dominio.Contratos;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infraestructura.Base;

public class UnitOfWork: UnitRepos, IUnitOfWork
{
    public UnitOfWork(IDbContext context) : base(context)
    {
        dbContext = context;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public string Commit()
    {
        try
        {
            return dbContext.SaveChanges() + " commit";
        }
        catch (Exception e)
        {
            var data = ((NpgsqlException)e.InnerException!).Data;
            return data["SqlState"] is string code ? code : "";
        }
    }
    
    private void Dispose(bool disposing)
    {
        if (!disposing || dbContext == null) return;
        ((DbContext)dbContext).Dispose();
        dbContext = null;
    }
}
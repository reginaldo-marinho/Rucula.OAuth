using Rucula.OAuth.LocalCredentials.Core.Entities;
using Rucula.OAuth.LocalCredentials.Core.Repositories;


namespace Rucula.OAuth.LocalCredentials.Infrastructure.Persistence.Repositories;

public class AuditProcessRepository : BaseRepository<AuditProcess>, IAuditProcessRepository
{
    public AuditProcessRepository(DbContextProject context) : base(context)
    {
    }
}

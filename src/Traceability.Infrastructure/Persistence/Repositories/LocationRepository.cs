using Microsoft.EntityFrameworkCore;
using Traceability.Domain.Locations.Entities;
using Traceability.Domain.Locations.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class LocationRepository(ApplicationDbContext context)
    : BaseRepository<Location>(context), ILocationRepository
{
    public Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Location?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Location>().FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
    }

    public Task<Location?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

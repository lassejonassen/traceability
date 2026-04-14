using Traceability.Domain.Locations.Entities;

namespace Traceability.Domain.Locations.Repositories;

public interface ILocationRepository : IBaseRepository<Location>
{
    Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken cancellationToken);
    Task<Location?> GetAsync(string name, CancellationToken cancellationToken);
    Task<Location?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
using Traceability.Domain.Materials.Entities;

namespace Traceability.Domain.Materials.Repositories;

public interface IMaterialRepository : IBaseRepository<Material>
{
    Task<IReadOnlyList<Material>> GetAllAsync(CancellationToken cancellationToken);
    Task<Material?> GetAsync(string name, CancellationToken cancellationToken);
    Task<Material?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
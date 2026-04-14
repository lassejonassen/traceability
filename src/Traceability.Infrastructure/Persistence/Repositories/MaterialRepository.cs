using Microsoft.EntityFrameworkCore;
using Traceability.Domain.Locations.Entities;
using Traceability.Domain.Materials.Entities;
using Traceability.Domain.Materials.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class MaterialRepository(ApplicationDbContext context)
    : BaseRepository<Material>(context), IMaterialRepository
{
    public Task<IReadOnlyList<Material>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Material?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Material>().FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
    }

    public Task<Material?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

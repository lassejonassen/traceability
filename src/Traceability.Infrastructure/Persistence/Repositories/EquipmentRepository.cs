using Microsoft.EntityFrameworkCore;
using Traceability.Domain.Equipments.Entities;
using Traceability.Domain.Equipments.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class EquipmentRepository(ApplicationDbContext context)
    : BaseRepository<Equipment>(context), IEquipmentRepository
{
    public Task<IReadOnlyList<Equipment>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Equipment?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Equipment>().FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
    }

    public Task<Equipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

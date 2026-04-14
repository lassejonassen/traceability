using Traceability.Domain.Equipments.Entities;

namespace Traceability.Domain.Equipments.Repositories;

public interface IEquipmentRepository : IBaseRepository<Equipment>
{
    Task<IReadOnlyList<Equipment>> GetAllAsync(CancellationToken cancellationToken);
    Task<Equipment?> GetAsync(string name, CancellationToken cancellationToken);
    Task<Equipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

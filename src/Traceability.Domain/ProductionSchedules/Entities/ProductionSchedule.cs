using Traceability.SharedKernel;

namespace Traceability.Domain.ProductionSchedules.Entities;

public sealed class ProductionSchedule : BaseEntity
{
    private ProductionSchedule() { }
    private ProductionSchedule(DateTimeOffset utcNow) : base(utcNow) { }

    public string ScheduleId { get; private set; } = string.Empty;

    public static Result<ProductionSchedule> Create(string scheduleId, DateTimeOffset utcNow)
    {
        var productionSchedule = new ProductionSchedule(utcNow)
        {
            ScheduleId = scheduleId,
        };

        return Result.Success(productionSchedule);
    }
}

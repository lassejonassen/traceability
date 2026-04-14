using Bogus;
using WebAPI.Contracts;

namespace Traceability.SIM.WorkerService;

internal sealed class DataGenerator : Faker<CaptureProductionEventRequest>
{
    public DataGenerator()
    {
        RuleFor(x => x.ProductionSchedule, "1");
        RuleFor(x => x.ProductionRequest, f => f.Random.Int(1, 9999).ToString());
        RuleFor(x => x.SegmentRequirement, "1");
        RuleFor(x => x.SegmentResponse, f => f.Random.Int(1, 999999).ToString());
        RuleFor(x => x.ProductionEventType, "MATERIALCONSUMED");
        RuleFor(x => x.EventId, "E");
        RuleFor(x => x.Material, f => f.Random.Int(1, 9).ToString());
        RuleFor(x => x.Equipment, f => f.System.ToString());
        RuleFor(x => x.Location, f => f.System.ToString());
        RuleFor(x => x.Lot, f => f.Random.Int(1, 9).ToString());
        RuleFor(x => x.SubLot, f => f.Random.Int(1, 9).ToString());
        RuleFor(x => x.Quantity, f => f.Random.Double(1000, 9999));
        RuleFor(x => x.UnitOfMeasure, f => "KG");
        RuleFor(x => x.ProcessSegment, f => f.Company.ToString());
    }
}

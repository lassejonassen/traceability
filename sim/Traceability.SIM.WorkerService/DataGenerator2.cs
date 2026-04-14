using WebAPI.Contracts;

namespace Traceability.SIM.WorkerService;

public static class DataGenerator2
{
    public static CaptureProductionEventRequest IntakeTankConsumed1()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALCONSUMED",
            EventId = "Consume",
            Material = "10001",
            Equipment = "A10C01U01",
            Location = "100101",
            Lot = "100000001",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C01U01"
        };
    }

    public static CaptureProductionEventRequest IntakeTankConsumed2()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALCONSUMED",
            EventId = "Consume",
            Material = "10002",
            Equipment = "A10C01U02",
            Location = "100102",
            Lot = "100000002",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C01U02"
        };
    }

    public static CaptureProductionEventRequest MixerConsumed1()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALCONSUMED",
            EventId = "Consume",
            Material = "10001",
            Equipment = "A10C02U01",
            Location = "100101",
            Lot = "100000002",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C02U01"
        };
    }

    public static CaptureProductionEventRequest MixerConsumed2()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALCONSUMED",
            EventId = "Consume",
            Material = "10002",
            Equipment = "A10C02U01",
            Location = "100102",
            Lot = "100000002",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C02U01"
        };
    }

    public static CaptureProductionEventRequest SiloConsume1()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALCONSUMED",
            EventId = "Consume",
            Material = "1100",
            Equipment = "A10C03U01",
            Location = "100201",
            Lot = "100000002",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C03U01"
        };
    }

    public static CaptureProductionEventRequest PackerConsume1()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALCONSUMED",
            EventId = "Consume",
            Material = "1100",
            Equipment = "A10C04U01",
            Location = "100301",
            Lot = "100000002",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C04U01"
        };
    }

    public static CaptureProductionEventRequest PackerProduce1()
    {
        return new()
        {
            ProductionSchedule = "1",
            ProductionRequest = "000026040001",
            SegmentRequirement = "1",
            SegmentResponse = "261502001",
            ProductionEventType = "MATERIALPRODUCED",
            EventId = "Produce",
            Material = "999999",
            Equipment = "A10C04U01",
            Location = "100401",
            Lot = "100000002",
            SubLot = "1",
            Quantity = 4000.0,
            UnitOfMeasure = "KG",
            ProcessSegment = "A10C04U01"
        };
    }
}

using System.Text;
using System.Text.Json;

namespace Traceability.SIM.WorkerService;

public class Worker2(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            HttpClient client = new HttpClient();

            var tankConsume1 = DataGenerator2.IntakeTankConsumed1();

            using StringContent tankConsumeJson1 = new(
                JsonSerializer.Serialize(tankConsume1),
                Encoding.UTF8,
                "application/json"
            );

            var tankConsumeRes1 = await client.PostAsync("https://localhost:7133/api/capture", tankConsumeJson1);

            var tankConsume2 = DataGenerator2.IntakeTankConsumed2();

            using StringContent tankConsumeJson2 = new(
                JsonSerializer.Serialize(tankConsume2),
                Encoding.UTF8,
                "application/json"
            );

            var tankConsumeRes2 = await client.PostAsync("https://localhost:7133/api/capture", tankConsumeJson2);

            var mixerConsume1 = DataGenerator2.MixerConsumed1();

            using StringContent mixerConsume1Json = new(
                JsonSerializer.Serialize(mixerConsume1),
                Encoding.UTF8,
                "application/json"
            );

            var mixerConsume1Res = await client.PostAsync("https://localhost:7133/api/capture", mixerConsume1Json);

            var mixerConsume2 = DataGenerator2.MixerConsumed2();

            using StringContent mixerConsume2Json = new(
                JsonSerializer.Serialize(mixerConsume2),
                Encoding.UTF8,
                "application/json"
            );

            var mixerConsume2Res = await client.PostAsync("https://localhost:7133/api/capture", mixerConsume2Json);

            var siloConsume1 = DataGenerator2.SiloConsume1();

            using StringContent siloConsume1Json = new(
                JsonSerializer.Serialize(mixerConsume2),
                Encoding.UTF8,
                "application/json"
            );

            var siloConsume1Res = await client.PostAsync("https://localhost:7133/api/capture", siloConsume1Json);

            var packerConsume1 = DataGenerator2.PackerConsume1();

            using StringContent packerConsume1Json = new(
                JsonSerializer.Serialize(packerConsume1),
                Encoding.UTF8,
                "application/json"
            );

            var packerConsume1Res = await client.PostAsync("https://localhost:7133/api/capture", packerConsume1Json);

            var pakcerProduce1 = DataGenerator2.PackerProduce1();

            using StringContent pakcerProduce1Json = new(
                JsonSerializer.Serialize(pakcerProduce1),
                Encoding.UTF8,
                "application/json"
            );

            var pakcerProduce1Res = await client.PostAsync("https://localhost:7133/api/capture", pakcerProduce1Json);

            return;
        }
    }
}

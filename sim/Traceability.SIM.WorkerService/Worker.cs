using System.Text;
using System.Text.Json;

namespace Traceability.SIM.WorkerService;

public class Worker(ILogger<Worker> logger) : BackgroundService
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

            var data = new DataGenerator().Generate();

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PostAsync("https://localhost:7133/api/capture", jsonContent);

            await Task.Delay(1000, stoppingToken);
        }
    }
}

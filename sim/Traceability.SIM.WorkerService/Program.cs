using Traceability.SIM.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<Worker2>();

var host = builder.Build();
host.Run();

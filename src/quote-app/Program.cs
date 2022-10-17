using Infrastructure;
using Quote.App;

var builder = Host
	.CreateDefaultBuilder(args)
	.ConfigureServices((_, services) =>
	{
		services.AddInfrastructureServices();
		services.AddHostedService<QuoteFetchingWorker>();
	})
	.UseConsoleLifetime();

var host = builder.Build();
await host.RunAsync();

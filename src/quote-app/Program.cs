using Quote.App;
using Quote.App.Infrastructure;

var builder = Host
	.CreateDefaultBuilder(args)
	.ConfigureServices((hostContext, services) =>
	{
		var configuration = hostContext.Configuration;
		var appConfiguration = configuration.GetSection("LegacyConfiguration");
		// Feel free to get rid of the below line if you cannot access internal artifact repository.
		ADEXS.Core.Util.Cache.ConfigurationProvider.UseConfiguration(appConfiguration);

		services.AddInfrastructureServices();
		services.AddHostedService<QuoteFetchingWorker>();
	})
	.UseConsoleLifetime();

var host = builder.Build();

await host.RunAsync();

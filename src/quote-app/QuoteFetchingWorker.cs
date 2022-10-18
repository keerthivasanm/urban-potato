using Quote.App.Domain;
using Spectre.Console;

namespace Quote.App;

public sealed class QuoteFetchingWorker : BackgroundService
{
	private readonly ILogger<QuoteFetchingWorker> _logger;
	private readonly IServiceScopeFactory _serviceScopeFactory;

	public QuoteFetchingWorker(ILogger<QuoteFetchingWorker> logger, IServiceScopeFactory serviceScopeFactory)
	{
		_logger = logger;
		_serviceScopeFactory = serviceScopeFactory;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation("Starting quote fetching service.");

		var table = new Table()
			.Centered()
			.Title("Live Quotes")
			.AddColumn(new TableColumn("Quote") { Width = 500 })
			.AddColumn(new TableColumn("Author") { Width = 25 })
			.Caption("Quotes are updated every 5 seconds")
			.Border(TableBorder.Rounded);

		await AnsiConsole
			.Live(table)
			.StartAsync(async tableContext =>
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					using var scope = _serviceScopeFactory.CreateScope();
					var store = scope.ServiceProvider.GetRequiredService<IQuoteService>();
					var randomQuote = await store.GetRandom();

					if (table.Rows.Count >= 25) table.Rows.RemoveAt(0);

					table.AddRow(
						new Markup($"[yellow]{Markup.Escape(randomQuote.Content)}[/]"),
						new Markup($"[red]{Markup.Escape(randomQuote.Author)}[/]"));

					tableContext.Refresh();
					await Task.Delay(5_000, stoppingToken);
				}
			});

		_logger.LogInformation("Stopping quote fetching service.");
	}
}

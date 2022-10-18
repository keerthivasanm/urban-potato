using Microsoft.Extensions.DependencyInjection;
using Quote.App.Domain;

namespace Quote.App.Infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddSingleton<IQuoteService, QuoteService>();
			return services;
		}
	}
}

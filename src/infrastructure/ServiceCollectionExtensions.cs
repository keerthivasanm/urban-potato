using domain;
using infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
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

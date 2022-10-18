using Flurl;
using Flurl.Http;
using Quote.App.Domain;

namespace Quote.App.Infrastructure;

public class QuoteService : IQuoteService
{
	private const string QuotableBaseUri = "https://api.quotable.io";

	public async Task<Quote.App.Domain.Quote> GetRandom()
	{
		var quote = await QuotableBaseUri
			.AppendPathSegment("random")
			.GetJsonAsync<Quote.App.Domain.Quote>();

		return quote;
	}
}

using domain;
using Flurl;
using Flurl.Http;

namespace infrastructure;

public class QuoteService : IQuoteService
{
	private const string QuotableBaseUri = "https://api.quotable.io";

	public async Task<Quote> GetRandom()
	{
		var quote = await QuotableBaseUri
			.AppendPathSegment("random")
			.GetJsonAsync<Quote>();

		return quote;
	}
}

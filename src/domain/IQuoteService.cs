namespace Quote.App.Domain;

public interface IQuoteService
{
	Task<global::Quote.App.Domain.Quote> GetRandom();
}

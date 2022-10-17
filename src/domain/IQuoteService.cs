namespace domain;

public interface IQuoteService
{
	Task<Quote> GetRandom();
}

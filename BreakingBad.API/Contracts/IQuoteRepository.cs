using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Contracts
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<QuoteDto>> GetAllQuotesAsync();

        Task<QuoteDto> GetQuoteById(int quoteId);

        // Task<EpisodeDto> CreateEpisodeAsync(Episode episode);

        Task<QuoteDto> CreateQuoteAsync(Quote quote);

        Task<QuoteDto> UpdateQuoteAsync(Quote quote);

        Task DeleteQuoteAsync(int quoteId);

        Task<bool> ExistsAsync(int quoteId);
    }
}
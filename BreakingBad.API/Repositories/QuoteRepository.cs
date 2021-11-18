using AutoMapper;
using BreakingBad.API.Contracts;
using BreakingBad.API.Models;
using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreakingBad.API.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public QuoteRepository(ApplicationDbContext context, IMapper mapper, LinkGenerator linkGenerator)
        {
            _context = context;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        public async Task<IEnumerable<QuoteDto>> GetAllQuotesAsync()
        {
            try
            {
                var quotes = await _context.Quotes.ToListAsync();
                var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

                return quotesDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting the quotes");
            }
        }

        public Task<QuoteDto> CreateQuoteAsync(Quote quote)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQuoteAsync(int quoteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int quoteId)
        {
            throw new NotImplementedException();
        }

        public Task<QuoteDto> GetQuoteById(int quoteId)
        {
            throw new NotImplementedException();
        }

        public Task<QuoteDto> UpdateQuoteAsync(Quote quote)
        {
            throw new NotImplementedException();
        }
    }
}
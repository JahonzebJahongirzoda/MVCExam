using Domain.Dtos;

namespace Infrastructure.Services;

public interface IQuoteService
{
    Task<List<QuoteDto>> GetQuotes();
    Task<QuoteDto?> GetQuote(int id);
    Task<QuoteDto?> CreateQuote(AddQuoteDto employeeDto);
    Task<QuoteDto?> UpdateQuote(UpdateQuoteDto employeeDto);
    Task<bool> DeleteQuote(int id);
}
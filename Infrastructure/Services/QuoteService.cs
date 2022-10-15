using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QuoteService:IQuoteService
{
    private readonly DataContext _context;

    public QuoteService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<QuoteDto>> GetQuotes()
    {
        var employees = await _context.Quotes
            .Select(e => new QuoteDto
            {
                Id = e.Id,
                ImageText = e.ImageText,
                QuoteText = e.QuoteText,
            })
            .ToListAsync();
        
        return employees;
    }
    
    public async Task<QuoteDto> GetQuote(int id)
    {
        var employee = await _context.Quotes
            .Select(e => new QuoteDto
            {
                Id = e.Id,
                ImageText = e.ImageText,
                QuoteText = e.QuoteText,
            })
            .FirstOrDefaultAsync(e => e.Id == id);
        
        return employee;
    }
    
    public async Task<QuoteDto?> CreateQuote(AddQuoteDto employeeDto)
    {
        var employee = new Quote
        {
            ImageText = employeeDto.ImageText,
            QuoteText = employeeDto.QuoteText,
        };
        
        await _context.Quotes.AddAsync(employee);
        await _context.SaveChangesAsync();
        
        employeeDto.Id = employee.Id;
        
        var employeeCreated = await GetQuote(employee.Id);
        return employeeCreated;
    }
    
    public async Task<QuoteDto?> UpdateQuote(UpdateQuoteDto employeeDto)
    {
        var employee = await _context.Quotes.FirstOrDefaultAsync(e => e.Id == employeeDto.Id);
        
        if (employee == null)
        {
            return null;
        }

        employee.ImageText = employeeDto.ImageText;
        employee.QuoteText = employeeDto.QuoteText;
        
        await _context.SaveChangesAsync();
        
        var employeeUpdated = await GetQuote(employee.Id);
        return employeeUpdated;
    }
    
    public async Task<bool> DeleteQuote(int id)
    {
        var employee = await _context.Quotes.FirstOrDefaultAsync(e => e.Id == id);
        
        if (employee == null)
        {
            return false;
        }
        
        _context.Quotes.Remove(employee);
        await _context.SaveChangesAsync();
        
        return true;
    }
    
    
}
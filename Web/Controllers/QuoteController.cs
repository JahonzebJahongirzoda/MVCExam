using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class QuoteController:Controller
{
    private readonly IQuoteService _quoteService;

    public QuoteController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var quotes = await _quoteService.GetQuotes();
        return View(quotes);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddQuoteDto quote)
    {
        await _quoteService.CreateQuote(quote);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var quote = await _quoteService.GetQuote(id);
        return View(quote);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateQuoteDto quote)
    {
        await _quoteService.UpdateQuote(quote);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _quoteService.DeleteQuote(id);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var quote = await _quoteService.GetQuote(id);
        return View(quote);
    }

}

namespace Domain.Dtos;

public class AddQuoteDto
{
    public int Id { get; set; }
    public string? QuoteText { get; set; }
    public string? ImageText { get; set; }
}
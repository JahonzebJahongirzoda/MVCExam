namespace Domain.Dtos;

public class UpdateQuoteDto
{

    public int Id { get; set; }
    public string? QuoteText { get; set; }
    public string? ImageText { get; set; }
}
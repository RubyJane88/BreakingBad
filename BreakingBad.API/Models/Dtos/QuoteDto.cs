namespace BreakingBad.API.Models.Dtos
{
    public class QuoteDto
    {
        public int QuoteId { get; set; }
        public string Quotes { get; set; }

        public string Author { get; set; }

        public string Series { get; set; }
    }
}
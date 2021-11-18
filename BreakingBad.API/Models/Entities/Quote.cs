namespace BreakingBad.API.Models.Entities
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public string Quotes { get; set; }

        public string Author { get; set; }

        public string Series { get; set; }
    }
}
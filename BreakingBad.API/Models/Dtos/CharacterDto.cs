namespace BreakingBad.API.Models.Dtos
{
    public sealed class CharacterDto
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Uri Img { get; set; }
        public string Nickname { get; set; }
        public string Portrayed { get; set; }

        public string Category { get; set; }

        public IEnumerable<string> Appearance { get; set; }

        public IEnumerable<string> BetterCallSaulAppearance { get; set; }

        public IEnumerable<string> Occupation { get; set; }
    }
}
namespace BreakingBad.API.Models.Dtos
{
    public class CharacterDto
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Uri Img { get; set; }
        public string Nickname { get; set; }
        public string Portrayed { get; set; }

        public Category Category { get; set; }

        public List<int> Appearance { get; set; }
        public List<int> BetterCallSaulAppearance { get; set; }
        public List<string> Occupation { get; set; }
    }

    public enum Category
    {
        BetterCallSaul,
        BreakingBad,
        BreakingBadBetterCallSaul
    };
}

using System.ComponentModel.DataAnnotations;

namespace BreakingBad.API.Models.Entities
{
    public sealed class Character
    {
        [Key]
        public int CharId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Uri Img { get; set; }
        public string Nickname { get; set; }
        public string Portrayed { get; set; }

        public Category Category { get; set; }

        // public List<int> Appearance { get; set; }
        // public List<int> BetterCallSaulAppearance { get; set; }

        // [NotMapped]
        public IEnumerable<string> Occupation { get; set; } = new List<string>();
    }

    public enum Category
    {
        BetterCallSaul,
        BreakingBad,
        BreakingBadBetterCallSaul
    };
}
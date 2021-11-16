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

        public string Category { get; set; }

        public IEnumerable<string> Appearance { get; set; } = new List<string>();

        public IEnumerable<string> BetterCallSaulAppearance { get; set; } = new List<string>();

        public IEnumerable<string> Occupation { get; set; } = new List<string>();

        //public List<Occupation> Occupations { get; init} = new List<Occupation>();
    }
}
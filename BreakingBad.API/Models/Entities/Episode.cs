using System.ComponentModel.DataAnnotations;

namespace BreakingBad.API.Models.Entities
{
    public sealed class Episode
    {
        [Key]
        public int EpisodeId { get; set; }

        public string Title { get; set; }

        public string? Season { get; set; }

        public DateTime AirDate { get; set; }

        public IEnumerable<string> Characters { get; set; } = new List<string>();

        public int Episodes { get; set; }

        public string Series { get; set; }
    }
}
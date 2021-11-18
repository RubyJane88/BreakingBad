namespace BreakingBad.API.Models.Dtos
{
    public class EpisodeDto
    {
        public int EpisodeId { get; set; }

        public string Title { get; set; }

        public DateTime AirDate { get; set; }

        public string Season { get; set; }

        // public Character CharacterId { get; set; }
        //
        // public List<Characters> Characters { get; set; } = new List<Characters>();

        public int Episodes { get; set; }

        public string Series { get; set; }
    }
}
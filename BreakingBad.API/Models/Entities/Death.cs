namespace BreakingBad.API.Models.Entities
{
    public class Death
    {
        public int DeathId { get; set; }

        public string Deaths { get; set; }

        public string Cause { get; set; }

        public string Responsible { get; set; }

        public string LastWords { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public int NumberOfDeaths { get; set; }
    }
}
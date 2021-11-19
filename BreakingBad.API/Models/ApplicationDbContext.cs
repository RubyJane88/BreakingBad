using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreakingBad.API.Models;

public class ApplicationDbContext : DbContext
{
    // public DbSet<Character> Characters { get; set; }
    public DbSet<Character> Characters => Set<Character>();

    public DbSet<Episode> Episodes => Set<Episode>();

    public DbSet<Quote> Quotes => Set<Quote>();

    public DbSet<Death> Deaths { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Orders");

    //Make all properties of max length, no need to specify for each property unless necessary
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(200);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Character>().Property(e => e.Name).HasMaxLength(200);

        var splitOccupationStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v)
            , v => v.Split(new[] { ';' }));
        modelBuilder.Entity<Character>().Property(nameof(Character.Occupation)).HasConversion(splitOccupationStringConverter);

        var splitAppearanceStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v)
            , v => v.Split(new[] { ';' }));
        modelBuilder.Entity<Character>().Property(nameof(Character.Appearance)).HasConversion(splitAppearanceStringConverter);

        var splitBetterCallSaulAppearanceStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v)
            , v => v.Split(new[] { ';' }));
        modelBuilder.Entity<Character>().Property(nameof(Character.BetterCallSaulAppearance)).HasConversion(splitBetterCallSaulAppearanceStringConverter);

        var splitCharactersStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v)
            , v => v.Split(new[] { ';' }));
        modelBuilder.Entity<Episode>().Property(nameof(Episode.Characters)).HasConversion(splitCharactersStringConverter);

        modelBuilder.Entity<Character>().HasData(

            new Character
            {
                CharId = 1,
                Name = "Jessie Pinkman",
                Birthday = new DateTime(1984, 09, 29),
                Occupation = new List<string>() { "Meth dealer" },

                Img = new Uri(
                    "https://vignette.wikia.nocookie.net/breakingbad/images/9/95/JesseS5.jpg/revision/latest?cb=20120620012441"),
                Nickname = "Cap n' Cook",
                Appearance = new List<string>() { "Breaking Bad" },
                Portrayed = "Aaron Paul",
                Category = "Breaking Bad",
                BetterCallSaulAppearance = new List<string>() { "None" },
            }

        );

        modelBuilder.Entity<Episode>().HasData(

            new Episode
            {
                EpisodeId = 27,
                Title = "Ozymandias",
                Season = "5",
                Episodes = 14,
                AirDate = new DateTime(2008, 09, 03),
                Characters = new List<string>() { "Walter White", "Hank Schrader" },
                Series = "1"
            },

            new Episode
            {
                EpisodeId = 6,
                Title = "Crazy Handful of Nothin",
                Season = "1",
                AirDate = new DateTime(2008, 02, 03),
                Characters = new List<string>()
                {
                    "Walter White",
                    "Jesse Pinkman",
                    "Skyler White",
                    "Hank Schrader",
                    "Marie Schrader",
                    "Walter White Jr.",
                    "Tuco Salamanca"
                },

                Episodes = 6,
                Series = "Breaking Bad"
            }

        );

        modelBuilder.Entity<Quote>().HasData(

            new Quote
            {
                QuoteId = 4,
                Quotes = "I watched Jane die. I was there. And I watched her die. I watched her overdose and choke to death. I could have saved her. But I didn’t.",
                Author = "Walter White",
                Series = "Breaking Bad"
            },

            new Quote
            {
                QuoteId = 7,
                Quotes = "Yeah, you do seem to have a little s*** creek action going... You know, FYI, you can buy a paddle.",
                Author = "Saul Goodman",
                Series = "Breaking Bad"
            },

            new Quote

            {
                QuoteId = 9,
                Quotes = "Funyuns are awesome.",
                Author = "Jesse Pinkman",
                Series = "Breaking Bad"
            },

            new Quote
            {
                QuoteId = 12,
                Quotes = "What good is being an outlaw when you have responsibilities.",
                Author = "Jesse Pinkman",
                Series = "Breaking Bad"
            }

        );

        modelBuilder.Entity<Death>().HasData(

            new Death

            {
                DeathId = 40,
                Deaths = "Bodyguards of Gus Fring",
                Cause = "Multiple gunshots.",
                Responsible = "Walter White",
                LastWords = "What, you got a problem with stairs?",
                Season = 4,
                Episode = 13,
                NumberOfDeaths = 2
            },

            new Death
            {
                DeathId = 28,
                Deaths = "Cartel Assassins",
                Cause = "Shot in close range.",
                Responsible = "Mike Ehrmantraut",
                LastWords = "Unknown",
                Season = 4,
                Episode = 4,
                NumberOfDeaths = 2
            },

            new Death
            {
                DeathId = 23,
                Deaths = "Rival Dealers",
                Cause = "Ran over with a van, then shot in the head.",
                Responsible = "Walter White",
                LastWords = "Unknown",
                Season = 3,
                Episode = 12,
                NumberOfDeaths = 2
            }

        );
    }
}
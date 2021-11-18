using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreakingBad.API.Models;

public class ApplicationDbContext : DbContext
{
    // public DbSet<Character> Characters { get; set; }
    public DbSet<Character> Characters => Set<Character>();

    public DbSet<Episode> Episodes => Set<Episode>();

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
                EpisodeId = 60,
                Title = "Ozymandias",
                Season = "5",
                Episodes = 14,
                AirDate = new DateTime(2008, 09, 03),
                // Characters = new List<Characters>(),
                Series = "1"
            }

        );
    }
}
using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreakingBad.API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v)
                , v => v.Split(new[] { ';' }));
            modelBuilder.Entity<Character>().Property(nameof(Character.Occupation)).HasConversion(splitStringConverter);

            // modelBuilder.Entity<Character>().HasData(
            //     new Character
            //     {
            //         CharId = 1,
            //         Name = "Jessie Pinkman",
            //         Birthday = new DateTime(1984, 09, 29),
            //         Occupation = new List<string>() { "Meth dealer" },
            //         Img = new Uri(
            //             "https://vignette.wikia.nocookie.net/breakingbad/images/9/95/JesseS5.jpg/revision/latest?cb=20120620012441"),
            //         Status = Status.Alive,
            //         Nickname = "Cap n' Cook",
            //         Appearance = new List<int>() { 1, 2, 3, 4, 5 },
            //         Portrayed = "Aaron Paul",
            //         Category = Category.BreakingBad,
            //         BetterCallSaulAppearance = new List<int>() { }

            //     },

            //     new Character
            //     {
            //         CharId = 2,
            //         Name = "Walter White",
            //         Birthday = new DateTime(1958, 09, 07),
            //         Occupation = new List<string>() { "High School Chemistry Teacher", "Meth King Pin" },
            //         Img = new Uri("https://static.wikia.nocookie.net/breakingbad/images/8/88/WalterWhite.png/revision/latest/scale-to-width-down/1000?cb=20140712163255&path-prefix=de"),
            //         Status = Status.PresumedDead,
            //         Nickname = "Heisenberg",
            //         Appearance = new List<int>() { 1, 2, 3, 4, 5 },
            //         Portrayed = "Bryan Cranston",
            //         Category = Category.BreakingBad,
            //         BetterCallSaulAppearance = new List<int>() { }

            //     },

            //     new Character
            //     {
            //         CharId = 3,
            //         Name = "Skyler White",
            //         Birthday = new DateTime(1970, 11, 08),
            //         Occupation = new List<string> {
            //         "House wife",
            //         "Book Keeper",
            //         "Car Wash Manager",
            //         "Taxi Dispatcher"
            //         },
            //         Img = new Uri("https://s-i.huffpost.com/gen/1317262/images/o-ANNA-GUNN-facebook.jpg"),
            //         Status = Status.Alive,
            //         Nickname = "Sky",
            //         Appearance = new List<int> { 1, 2, 3, 4, 5 },
            //         Portrayed = "Anna Gunn",
            //         BetterCallSaulAppearance = new List<int>() { }
            //     },

            //     new Character
            //     {
            //         CharId = 4,
            //         Name = "Walter White Jr.",
            //         Birthday = new DateTime(1993, 07, 08),
            //         Occupation = new List<string> { "Teenager" },
            //         Img = new Uri("https://media1.popsugar-assets.com/files/thumbor/WeLUSvbAMS_GL4iELYAUzu7Bpv0/fit-in/1024x102"),

            //         Status = Status.Alive,
            //         Nickname = "Flynn",
            //         Appearance = new List<int>() { 1, 2, 3, 4, 5 },
            //         Portrayed = "RJ Mitte",
            //         Category = Category.BreakingBad,
            //         BetterCallSaulAppearance = new List<int>() { },

            //     }

            // );

            // base.OnModelCreating(modelBuilder);
        }



    }
}

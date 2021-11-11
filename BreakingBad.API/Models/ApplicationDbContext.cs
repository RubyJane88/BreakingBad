using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreakingBad.API.Models;

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
                Portrayed = "Aaron Paul",
                Category = Category.BreakingBad,

            }
            );

        base.OnModelCreating(modelBuilder);
    }



}


using BreakingBad.API.Models;
using BreakingBad.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();



/* EF Core DbContext */
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration["MSSQLServer:ConnectionString"]));

//In Memory 
// builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDb"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Breaking Bad", Version = "v1" });
});

//Automapper for mapping Entities to Dtos -
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// //CORS
builder.Services.AddCors();

// //Health Checks 
builder.Services.AddHealthChecks();

/* Scrutor */
builder.Services.Scan(scan =>
    scan.FromCallingAssembly()
        .AddClasses()
        .AsMatchingInterface());


/* auto map from interface to service because of scrutor e.g.
           from services.AddScoped<IPerson, Person>
           to services.AddScoped<Person> only */
builder.Services.AddScoped<CharacterRepository>();




// This method gets called by the runtime.
// Use this method to configure the HTTP request pipeline.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Breaking Bad v1"));
}



/* CORS Policy */
app.UseCors(b =>
{
    b.AllowAnyOrigin();
    b.AllowAnyHeader();
    b.AllowAnyMethod();
});


app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

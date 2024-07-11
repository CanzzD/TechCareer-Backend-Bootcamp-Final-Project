using FinalProject.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SocialAppDbContext>(options=>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql-connection");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

SeedData.TestVerileriniDoldur(app);

app.MapGet("/", () => "Hello World!");

app.Run();

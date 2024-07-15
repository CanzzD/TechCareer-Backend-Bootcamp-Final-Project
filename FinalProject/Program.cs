using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete;
using FinalProject.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SocialAppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sql-connection"]);
});

builder.Services.AddScoped<IPostRepository, EfPostRepostory>();
builder.Services.AddScoped<ITagRepository, EfTagRepostory>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "post-details",
    pattern: "posts/{url}",
    defaults: new { controller = "Posts", action = "Details" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}"
);

app.Run();

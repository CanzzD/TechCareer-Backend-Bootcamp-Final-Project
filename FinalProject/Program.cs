using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete;
using FinalProject.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SocialAppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sql-connection"]);
});

builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
    options.LoginPath = "/Users/Login";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "products-details",
    pattern: "products/details/{url}",
    defaults: new { controller = "Products", action = "Details" }
);

app.MapControllerRoute(
    name: "products_by_category",
    pattern: "products/category/{category}",
    defaults: new{controller = "Products", action = "Index"}
);
app.MapControllerRoute(
    name: "user_profile",
    pattern: "profile/{username}",
    defaults: new{controller = "Users", action = "Profile"}
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
);

app.Run();

using FinalProject.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Concrete.EfCore{

    public static class SeedData{

    public static void TestVerileriniDoldur(IApplicationBuilder app){
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<SocialAppDbContext>();
        if(context != null){
            if(context.Database.GetPendingMigrations().Any()){
                context.Database.Migrate();
            }
            if(!context.Categories.Any()){
                context.Categories.AddRange(
                    new Entity.Category{CategoryName = "web programlama",CategoryUrl = "web-programlama",Color = Entity.CategoryColors.primary},
                    new Entity.Category{CategoryName = "backend",CategoryUrl = "backend", Color = Entity.CategoryColors.danger},
                    new Entity.Category{CategoryName = "game",CategoryUrl = "game", Color=Entity.CategoryColors.warning},
                    new Entity.Category{CategoryName = "fullstack",CategoryUrl = "full-stack", Color = Entity.CategoryColors.success},
                    new Entity.Category{CategoryName = "php",CategoryUrl = "php", Color = Entity.CategoryColors.info}
                );
                context.SaveChanges();
            }
            if(!context.Users.Any()){
                context.Users.AddRange(
                    new Entity.User {UserName = "ahmetkaya", Name= "Ahmet Kaya",Email="info@ahmetkaya.com",Password="123456", UserImage = "1.jpg"},
                    new Entity.User {UserName = "selinkarsli",Name= "Selin Karslı",Email="info@selinkarsli.com",Password="123456", UserImage = "1.jpg"}
                );
                context.SaveChanges();
            }
            if(!context.Products.Any()){
                context.Products.AddRange(
                    new Entity.Product{
                        ProductTitle = "İphone 15 Pro Max Sıfır Ayarında",
                        ProductDescription = "temiz kullanılmış 6 aylık 15 pro max.",
                        ProductUrl = "iphone-15",
                        ProductPrice=50000,
                        IsActive = true,
                        ProductPublishedOn = DateTime.Now.AddDays(-10),
                        Categories = context.Categories.Take(3).ToList(),
                        Image = "1.jpg",
                        UserId = 1,
                        Comments = new List<Entity.Comment>{
                            new Entity.Comment {CommentText = "iyi bir bootcamp", CommentPublishedOn = DateTime.Now.AddDays(-20), UserId = 1},
                            new Entity.Comment {CommentText = "tavsiye ederim", CommentPublishedOn = DateTime.Now.AddDays(-10), UserId = 2},
                        }
                    },
                    new Entity.Product{
                        ProductTitle = "Unity Game",
                        ProductDescription = "unity ile oyun yapımı güzeldir. Bu bootcampte yenilikler öğreneceğiz.",
                        ProductUrl = "unity-game",
                        ProductPrice=780,
                        IsActive = true,
                        ProductPublishedOn = DateTime.Now.AddDays(-8),
                        Categories = context.Categories.Take(4).ToList(),
                        Image = "2.jpg",
                        UserId = 1
                    },
                    new Entity.Product{
                        ProductTitle = "Php Bootcamp",
                         ProductDescription = "Php ile web sitesi yapımı. Bu bootcampte yenilikler öğreneceğiz.",
                        ProductPrice = 500,
                        ProductUrl = "php-bootcamp",
                        IsActive = true,
                        ProductPublishedOn = DateTime.Now.AddDays(-5),
                        Categories = context.Categories.Take(2).ToList(),
                        Image = "3.jpeg",
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
    }
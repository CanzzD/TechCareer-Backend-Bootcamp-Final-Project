using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Concrete.EfCore
{

    public static class SeedData
    {

        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<SocialAppDbContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Entity.Category { CategoryName = "Teknoloji", CategoryUrl = "Teknoloji" },
                        new Entity.Category { CategoryName = "Erkek Giyim", CategoryUrl = "Erkek Giyim" },
                        new Entity.Category { CategoryName = "Kadın Giyim", CategoryUrl = "Kadın Giyim" },
                        new Entity.Category { CategoryName = "Mutfak", CategoryUrl = "Mutfak" },
                        new Entity.Category { CategoryName = "Tatil", CategoryUrl = "Tatil" }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User { Name = "Emre",Surname="Aşık" },
                        new Entity.User { Name = "Onur",Surname="Çelik" },
                        new Entity.User { Name = "Can",Surname="Özdemir"}
                    );
                    context.SaveChanges();
                }
                if (!context.Events.Any())
                {
                    context.Events.AddRange(
                        new Entity.Event
                        {
                            EventTitle = "Coffee Talk",
                            EventDescription = "Coffee Talk With Onur Celik",
                            StartTime = DateTime.Now.AddDays(-10),
                            EndTime = DateTime.Now.AddDays(-5),
                            OrganizerId = 1
                        }
                    );
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Entity.Product
                        {
                            ProductTitle = "İphone 15 Pro Max",
                            ProductDescription = "İphone 15 Pro Max 256Gb 6 aylık cihaz sorunsuz.",
                            ProductPrice = 50000,
                            ProductUrl="iphone-15",
                            Image = "1.jpg",
                            IsActive = true,
                            ProductPublishedOn = DateTime.Now.AddDays(-10),
                            Categories = context.Categories.Take(1).ToList(),
                            UserId = 1
                        },
                        new Entity.Product
                        {
                            ProductTitle = "Kadın Kaban",
                            ProductDescription = "Kadın Kaban Kalın Kışlık ürün.",
                            ProductPrice = 50000,
                            ProductUrl="kadın-kaban",
                            Image = "2.jpg",
                            IsActive = true,
                            ProductPublishedOn = DateTime.Now.AddDays(-5),
                            Categories = context.Categories.Take(2).ToList(),
                            UserId = 1
                        },
                        new Entity.Product
                        {
                            ProductTitle = "Erkek Ayakkabı",
                            ProductDescription = "42 numara erkek ayakkabı",
                            ProductPrice = 50000,
                            ProductUrl="erkek-ayakkabı",
                            Image = "3.jpeg",
                            IsActive = true,
                            ProductPublishedOn = DateTime.Now.AddDays(-10),
                            Categories = context.Categories.Take(3).ToList(),
                            UserId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
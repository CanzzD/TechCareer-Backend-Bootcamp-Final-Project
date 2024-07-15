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
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Entity.Tag { TagText = "Teknoloji", TagUrl = "Teknoloji" },
                        new Entity.Tag { TagText = "Yapay Zeka", TagUrl = "Yapay Zeka" },
                        new Entity.Tag { TagText = "Tatil", TagUrl = "Tatil" },
                        new Entity.Tag { TagText = "Yemek", TagUrl = "Yemek" },
                        new Entity.Tag { TagText = "Oyun", TagUrl = "Oyun" }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User { UserName = "emreasik" },
                        new Entity.User { UserName = "onurcelik" },
                        new Entity.User { UserName = "canozdemir" }
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
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Entity.Post
                        {
                            PostTitle = "asp .net core",
                            PostContent = "asp .net core bootcampi güzeldir.",
                            PostUrl="asp-netcore",
                            PostImage = "1.png",
                            IsActive = true,
                            PostPublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Entity.Post
                        {
                            PostTitle = "Unity Game",
                            PostContent = "unity ile oyun yapımı güzeldir.",
                            PostUrl="unity-game",
                            PostImage = "2.png",
                            IsActive = true,
                            PostPublishedOn = DateTime.Now.AddDays(-8),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        },
                        new Entity.Post
                        {
                            PostTitle = "Php Bootcamp",
                            PostContent = "Php ile web sitesi yapımı",
                            PostUrl="php-bootcamp",
                            PostImage = "3.png",
                            IsActive = true,
                            PostPublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 3
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
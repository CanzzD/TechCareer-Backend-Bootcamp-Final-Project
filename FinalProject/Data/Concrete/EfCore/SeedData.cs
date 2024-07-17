using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using FinalProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<SocialAppDbContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { CategoryName = "Teknoloji", CategoryUrl = "Teknoloji" },
                        new Category { CategoryName = "Erkek Giyim", CategoryUrl = "Erkek Giyim" },
                        new Category { CategoryName = "Kadın Giyim", CategoryUrl = "Kadın Giyim" },
                        new Category { CategoryName = "Mutfak", CategoryUrl = "Mutfak" },
                        new Category { CategoryName = "Tatil", CategoryUrl = "Tatil" }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { Name = "Emre", Surname = "Aşık", IsSeller = true },
                        new User { Name = "Onur", Surname = "Çelik" },
                        new User { Name = "Can", Surname = "Özdemir" }
                    );
                    context.SaveChanges();
                }

                if (!context.Sellers.Any())
                {
                    context.Sellers.AddRange(
                        new Seller { StoreName = "Emrenin Yeri", UserId = 1 },
                        new Seller { StoreName = "Kahve Dünyası", UserId = 2 },
                        new Seller { StoreName = "Tekno Kent", UserId = 3 }
                    );
                    context.SaveChanges();
                }

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(
                        new Order
                        {
                            OrderDate = DateTime.Now,
                            UserId = 1,
                            OrderItems = new List<OrderItem> { new OrderItem { OrderId = 1 } }
                        },
                        new Order { OrderDate = DateTime.Now, UserId = 2 }
                    );
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            ProductName = "İphone 15 Pro Max",
                            ProductDescription = "İphone 15 Pro Max 256Gb 6 aylık cihaz sorunsuz.",
                            ProductPrice = 50000,
                            ProductUrl = "iphone-15",
                            Image = "1.jpg",
                            StockQuantity = 5,
                            Categories = context.Categories.Take(1).ToList(),
                            SellerId = 1,
                            Reviews = new List<Review>{
                                new Review {ReviewText="Ürün çok güzel harika"},
                                new Review {ReviewText="Parasını hak etmiyor"}
                            }
                        },
                        new Product
                        {
                            ProductName = "Kadın Kaban",
                            ProductDescription = "Kadın Kaban Kalın Kışlık ürün.",
                            ProductPrice = 50000,
                            ProductUrl = "kadın-kaban",
                            Image = "2.jpg",
                            StockQuantity = 12,
                            Categories = context.Categories.Skip(1).Take(1).ToList(),
                            SellerId = 2,
                            Reviews = new List<Review>{
                                new Review {ReviewText="Ürün çok güzel harika"},
                                new Review {ReviewText="Parasını hak etmiyor"}
                            }
                        },
                        new Product
                        {
                            ProductName = "Erkek Ayakkabı",
                            ProductDescription = "42 numara erkek ayakkabı",
                            ProductPrice = 50000,
                            ProductUrl = "erkek-ayakkabı",
                            Image = "3.jpeg",
                            StockQuantity = 21,
                            Categories = context.Categories.Skip(2).Take(1).ToList(),
                            SellerId = 3,
                            Reviews = new List<Review>{
                                new Review {ReviewText="Ürün çok güzel harika"},
                                new Review {ReviewText="Parasını hak etmiyor"}
                            }
                        }
                    );
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving products: {ex.Message}");
                    }
                }
            }
        }
    }
}

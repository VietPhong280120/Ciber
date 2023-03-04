using CiberWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace CiberWeb.Data
{
    public static class CiberDataExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleAdminId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleUserId = new Guid("5B900F33-7B27-4DC0-B796-DC867F74A3B4");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUserRole>().HasData(
                new AppUserRole()
                {
                    Id = roleAdminId,
                    Name = "admin",
                    NormalizedName = "admin",
                },
                new AppUserRole()
                {
                    Id = roleUserId,
                    Name = "user",
                    NormalizedName = "user",
                }
            );
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Asdfgh1@3"),
                    Address = "Ha noi"

                }
            );
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>()
            {
                UserId = adminId,
                RoleId = roleAdminId,
            });
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID=1,
                    Name = "T-Shirt",
                    Description = "T-shirt",

                },
                new Category()
                {
                    ID=2,
                    Name = "Shirt",
                    Description = "Shirt"
                },
                new Category()
                {
                    ID=3,
                    Name = "Jean",
                    Description = "Jean",
                },
                new Category()
                {
                    ID=4,
                    Name = "Shorts",
                    Description = "Shorts"
                }

            );
            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   ID=1,
                   Name = "Man T-shirt 1",
                   CategoryId = 1,
                   Price = 100000,
                   Quantity = 100
               },
               new Product()
                {
                    ID=2,
                    Name = "Man T-shirt 2",
                    CategoryId = 1,
                    Price = 100000,
                    Quantity = 100
                },
               new Product()
               {
                   ID=3,
                   Name = "Man T-shirt 3",
                   CategoryId = 1,
                   Price = 100000,
                   Quantity = 100
               },
               new Product()
               {
                   ID=4,
                   Name = "Man shirt 1",
                   CategoryId = 2,
                   Price = 100000,
                   Quantity = 100
               },
               new Product()
               {
                   ID=5,
                   Name = "Man shirt 2",
                   CategoryId = 2,
                   Price = 100000,
                   Quantity = 100
               },
               new Product()
               {
                   ID = 6,
                   Name = "Jean 1",
                   CategoryId = 3,
                   Price = 100000,
                   Quantity = 100
               },
               new Product()
               {
                   ID = 7,
                   Name = "Jean 2",
                   CategoryId = 3,
                   Price = 100000,
                   Quantity = 100
               },
               new Product()
               {
                   ID = 8,
                   Name = "Shorts 1",
                   CategoryId = 4,
                   Price = 100000,
                   Quantity = 100
               },
                new Product()
                {
                    ID = 9,
                    Name = "Shorts 2",
                    CategoryId = 4,
                    Price = 100000,
                    Quantity = 100
                });
        }
    }
}

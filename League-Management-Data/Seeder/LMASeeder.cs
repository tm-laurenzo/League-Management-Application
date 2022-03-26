using League_Management_Data.Context;
using League_Management_Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Data.Seeder
{
    public class LMASeeder
    {
        public static async Task SeedData(LMADbContext dbContext, UserManager<User> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            var baseDir = Directory.GetCurrentDirectory();

            await dbContext.Database.EnsureCreatedAsync();

            if (!dbContext.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "ClubOwner", "Manager", "Player", "Agent" };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Chibuike",
                    LastName = "Chidolue",
                    UserName = "Laurenzo",
                    Email = "info@lma.com",
                    PhoneNumber = "09043546576",
                    Gender = "Male",
                    Age = 34,
                    IsActive = true,
                    PublicId = null,
                    Avatar = "http://placehold.it/32x32",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                user.EmailConfirmed = true;
                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, "Admin");

                var path = File.ReadAllText(FilePath(baseDir, "JSON/users.json"));

                var lmaUsers = JsonConvert.DeserializeObject<List<User>>(path);
                for (int i = 0; i < 5; i++)
                {
                    lmaUsers[i].EmailConfirmed = true;
                    await userManager.CreateAsync(lmaUsers[i], "Password@123");
                    if (i < 1)
                    {
                        await userManager.AddToRoleAsync(lmaUsers[i], "Admin");
                    }
                    else if (i >= 20 && i < 40)
                    {
                        await userManager.AddToRoleAsync(lmaUsers[i], "Manager");
                    }
                    else if (i >= 20 && i < 40)
                    {
                        await userManager.AddToRoleAsync(lmaUsers[i], "Manager");
                    }
                }
            }


            // Bookings and Payment //I am a badass C# dev
          /*  if (!dbContext.Bookings.Any())
            {
                var path = File.ReadAllText(FilePath(baseDir, "Json/bookings.json"));

                var bookings = JsonConvert.DeserializeObject<List<Booking>>(path);
                await dbContext.Bookings.AddRangeAsync(bookings);
            }

            // Hotels, roomtypes n rooms
            if (!dbContext.Hotels.Any())
            {
                var path = File.ReadAllText(FilePath(baseDir, "Json/Hotel.json"));

                var hotels = JsonConvert.DeserializeObject<List<Hotel>>(path);
                await dbContext.Hotels.AddRangeAsync(hotels);
            }

            // Whishlist
            if (!dbContext.WishLists.Any())
            {
                var path = File.ReadAllText(FilePath(baseDir, "Json/wishlists.json"));

                var wishList = JsonConvert.DeserializeObject<List<WishList>>(path);
                await dbContext.WishLists.AddRangeAsync(wishList);
            }
         */

            await dbContext.SaveChangesAsync();
        }

        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}

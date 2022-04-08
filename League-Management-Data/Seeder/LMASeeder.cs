﻿using League_Management_Data.Context;
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
                /* seed theg json*/
                for (int i = 0; i < 5; i++)
                {
                    lmaUsers[i].EmailConfirmed = true;
                    await userManager.CreateAsync(lmaUsers[i], "Password@123");
                    if (i < 20)
                    {
                        await userManager.AddToRoleAsync(lmaUsers[i], "ClubOwner");

                    }
                    
                }
            }
            await dbContext.SaveChangesAsync();
        }

        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}

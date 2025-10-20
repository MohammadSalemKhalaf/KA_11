using KA_11.DAL.Data;
using KA_11.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Utils
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager; 

        public SeedData(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager 
            )
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }

            if (!await _context.Categories.AnyAsync())
            {
                await _context.Categories.AddRangeAsync(
                    new Category { Name = "Clothes" },
                    new Category { Name = "Mobiles" }
                );
            }

            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Apple" },
                    new Brand { Name = "Nike" }
                );
            }

            await _context.SaveChangesAsync();
        }

        public async Task IdentityDataSeedingAsync()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email = "mohammad@gmail.com",
                    FullName = "Mohammad Khalaf",
                    PhoneNumber = "0569581366",
                    UserName = "mbaboshi",
                };

                var user2 = new ApplicationUser()
                {
                    Email = "baraa@gmail.com",
                    FullName = "Baraa Khalaf",
                    PhoneNumber = "0569581344",
                    UserName = "bbaboshi",
                };

                var user3 = new ApplicationUser()
                {
                    Email = "ahmad@gmail.com",
                    FullName = "Ahmad Khalaf",
                    PhoneNumber = "0569581355",
                    UserName = "ababoshi",
                };

                await _userManager.CreateAsync(user1, "Password@123"); 
                await _userManager.CreateAsync(user2, "Password@123");
                await _userManager.CreateAsync(user3, "Password@123");

                await _userManager.AddToRoleAsync(user1, "Admin");
                await _userManager.AddToRoleAsync(user2, "SuperAdmin");
                await _userManager.AddToRoleAsync(user3, "Customer");
            }

            await _context.SaveChangesAsync();
        }
    }
}
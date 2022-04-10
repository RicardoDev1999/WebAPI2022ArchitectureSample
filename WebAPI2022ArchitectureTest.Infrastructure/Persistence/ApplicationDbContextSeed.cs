using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Domain.Enums;
using WebAPI2022ArchitectureTest.Domain.Models;
using WebAPI2022ArchitectureTest.Infrastructure.Identity;

namespace WebAPI2022ArchitectureTest.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "admin", Email = "admin@admin.com" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Admin123!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoItems.Any())
            {
                context.TodoItems.AddRange(new List<TodoItem>
                {
                    new TodoItem { Title = "Apples", Status = TodoItemStatus.Created},
                    new TodoItem { Title = "Milk", Status = TodoItemStatus.Draft},
                    new TodoItem { Title = "Bread", Status = TodoItemStatus.Draft }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}

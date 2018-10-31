using AppService.Class;
using AppService.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForMySQLdb.Data;

namespace WebApplicationForMySQLdb.Models
{
    public class DbInitializer
    {
        private static Queue rolesNames = new Queue();
        
        public static Queue RolesNames { get => rolesNames; set => rolesNames = value; }

        public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            IdentityResult roleResult;
            foreach (var roleName in rolesNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName.ToString());
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName.ToString()));
                }
            }
        }
    }
}

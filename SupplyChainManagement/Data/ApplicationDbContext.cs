using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyChainManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserInformation> CustomUserInformation { get; set; }
    }
}

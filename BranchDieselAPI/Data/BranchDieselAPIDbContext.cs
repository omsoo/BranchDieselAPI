using BranchDieselAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BranchDieselAPI.Data
{
    public class BranchDieselAPIDbContext : DbContext
    {
        public BranchDieselAPIDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<ContactUser> ContactUsers { get; set; }
    }
}

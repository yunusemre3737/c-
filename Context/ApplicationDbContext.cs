using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }


}

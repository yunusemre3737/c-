using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Context
{
    // Kullanicilar özelliğinin bir DbSet olduğunu ve bu DbSet'in Kullanici tipindeki nesneleri içerdiğini belirtir.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
    
    

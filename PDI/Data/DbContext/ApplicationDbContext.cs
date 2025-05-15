
using Microsoft.EntityFrameworkCore;
using PDI.DTO;
namespace PDI.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Interview> Interviews { get; set; }
    }
}

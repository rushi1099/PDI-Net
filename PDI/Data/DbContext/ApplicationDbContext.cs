
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Interview>()
            //    .HasOne(i => i.HrName)                // Navigation property in Interview class
            //    .HasForeignKey(i => i.HrEmail)        // FK in Interview
            //    .HasPrincipalKey(u => u.Email)        // PK in User
            //    .OnDelete(DeleteBehavior.Restrict);   // Configure delete behavior
        }
    }
}

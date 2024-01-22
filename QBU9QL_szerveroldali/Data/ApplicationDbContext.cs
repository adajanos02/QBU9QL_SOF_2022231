using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SiteUser> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            

            builder.Entity<Travel>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);

            builder.Entity<Travel>().HasData(new Travel[]
            {
                new Travel("107887a9-4a29-4dca-adb1-adb179559207","Abádszalók","Tiszaderzs", 15),
                
            });
        }

        
    }
}
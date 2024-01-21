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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-QBU9QL_szerveroldali-33a91210-fcc2-48c9-95de-42736c100696;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
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
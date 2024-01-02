using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Contact>()
        //        .HasOne(t => t.Owner)
        //        .WithMany()
        //        .HasForeignKey(t => t.PhoneNumber)
        //        .OnDelete(DeleteBehavior.Cascade);
        //    base.OnModelCreating(builder);
        //}
    }
}
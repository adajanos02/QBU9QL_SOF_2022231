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
            base.OnModelCreating(builder);
            

            //builder.Entity<Contact>().HasData(new Contact[]
            //{
            //    new Contact("Anya", "+36204457996"),
            //    new Contact("Apa", "+36206694477"),
            //});
        }

        //protected override void Seed(ApplicationDbContext context)
        //{
        //    if (!context.Contacts.Any())
        //    {
        //        var initialData = new List<Contact>
        //        {
        //            new Contact {Name= "Anya", PhoneNumber = "+36204457996"},
        //            new Contact {Name = "Apa", PhoneNumber = "+36206694477"},
        //        };

        //        context.Contacts.AddRange(initialData);
        //        context.SaveChanges();
        //    }
        //}
    }
}
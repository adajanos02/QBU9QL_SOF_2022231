using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //if (!context.Travels.Any())
                //{
                //    context.Travels.AddRange(new List<Travel>()
                //    {
                //        new Travel()
                //        {
                //            OwnerId = "107887a9-4a29-4dca-adb1-adb179559207",
                //            StartingPoint = "Balatonfüred",
                //            Destination = "Pilisszentgyörgy",
                //            Distance = 350,
                //        },

                //        new Travel()
                //        {
                //            OwnerId = "b4a5c9a7-487a-4258-a607-676622be8cb7",
                //            StartingPoint = "Eger",
                //            Destination = "Lillafüred",
                //            Distance = 120,
                //        },

                //        new Travel()
                //        {
                //            OwnerId = "97996288-040f-4477-9ee1-397b9ef5749f",
                //            StartingPoint = "Békéscsaba",
                //            Destination = "Párkány",
                //            Distance = 380,
                //        }

                //    });
                //    context.SaveChanges();
                //}

                //if (!context.Contacts.Any())
                //{
                //    context.Contacts.AddRange(new List<Contact>()
                //    {
                //        new Contact()
                //        {
                //            OwnerId = "107887a9-4a29-4dca-adb1-adb179559207",
                //            Name = "Mentők",
                //            PhoneNumber = "104"
                //        },

                //        new Contact()
                //        {
                //            OwnerId = "b4a5c9a7-487a-4258-a607-676622be8cb7",
                //            Name = "Mentők",
                //            PhoneNumber = "104"
                //        },

                //        new Contact()
                //        {
                //            OwnerId = "97996288-040f-4477-9ee1-397b9ef5749f",
                //            Name = "Mentők",
                //            PhoneNumber = "104"
                //        },
                //    });
                //    context.SaveChanges();
                //}
            }
        }
    }
}

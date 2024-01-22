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

                if (!context.Travels.Any())
                {
                    context.Travels.AddRange(new List<Travel>()
                    {
                        new Travel()
                        {
                            OwnerId = "705f4658-d61c-40e7-9a7c-f635e583ce39",
                            StartingPoint = "Balatonfüred",
                            Destination = "Pilisszentgyörgy",
                            Distance = 350,
                        },

                        new Travel()
                        {
                            OwnerId = "80d6005b-1f28-4c62-8386-1b7fb787459b",
                            StartingPoint = "Eger",
                            Destination = "Lillafüred",
                            Distance = 120,
                        },

                        new Travel()
                        {
                            OwnerId = "ad21259c-86dc-43f1-bb95-f6d2cd9fbc1b",
                            StartingPoint = "Békéscsaba",
                            Destination = "Párkány",
                            Distance = 380,
                        },

                    });
                    context.SaveChanges();
                }

                if (!context.Contacts.Any())
                {
                    context.Contacts.AddRange(new List<Contact>()
                    {
                        new Contact()
                        {
                            OwnerId = "705f4658-d61c-40e7-9a7c-f635e583ce39",
                            Name = "Mentők",
                            PhoneNumber = "104"
                        },

                        new Contact()
                        {
                            OwnerId = "80d6005b-1f28-4c62-8386-1b7fb787459b",
                            Name = "Mentők",
                            PhoneNumber = "104"
                        },

                        new Contact()
                        {
                            OwnerId = "ad21259c-86dc-43f1-bb95-f6d2cd9fbc1b",
                            Name = "Mentők",
                            PhoneNumber = "104"
                        },

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

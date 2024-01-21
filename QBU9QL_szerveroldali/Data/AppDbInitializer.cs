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
                            OwnerId = "2c3a4c83-4df1-4469-a243-fb8cb21d08fd",
                            StartingPoint = "Balatonfüred",
                            Destination = "Pilisszentgyörgy",
                            Distance = 350,
                        },

                        new Travel()
                        {
                            OwnerId = "562958d3-4fa5-4dd4-b5ed-ac5b677371b0",
                            StartingPoint = "Eger",
                            Destination = "Lillafüred",
                            Distance = 120,
                        },

                        new Travel()
                        {
                            OwnerId = "ba6517f1-a5e4-4aa2-a62c-d8ea2ebd3a9e",
                            StartingPoint = "Békéscsaba",
                            Destination = "Párkány",
                            Distance = 380,
                        },

                        new Travel()
                        {
                            OwnerId = "ebbee41d-05fe-41b6-8991-f2baf9893ad0",
                            StartingPoint = "Abádszalók",
                            Destination = "Szilvásvárad",
                            Distance = 220,
                        }

                    });
                    context.SaveChanges();
                }

                if (!context.Contacts.Any())
                {
                    context.Contacts.AddRange(new List<Contact>()
                    {
                        new Contact()
                        {
                            OwnerId = "2c3a4c83-4df1-4469-a243-fb8cb21d08fd",
                            Name = "Mentők",
                            PhoneNumber = "104"
                        },

                        new Contact()
                        {
                            OwnerId = "562958d3-4fa5-4dd4-b5ed-ac5b677371b0",
                            Name = "Mentők",
                            PhoneNumber = "104"
                        },

                        new Contact()
                        {
                            OwnerId = "ba6517f1-a5e4-4aa2-a62c-d8ea2ebd3a9e",
                            Name = "Mentők",
                            PhoneNumber = "104"
                        },

                        new Contact()
                        {
                            OwnerId = "ebbee41d-05fe-41b6-8991-f2baf9893ad0",
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

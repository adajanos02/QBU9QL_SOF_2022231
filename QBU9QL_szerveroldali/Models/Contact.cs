using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBU9QL_szerveroldali.Models
{
    public class Contact
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public string OwnerId { get; set; }

        [NotMapped]
        public virtual SiteUser Owner { get; set; }

        public Contact()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Contact(string name, string phoneNumber)
        {
            Id = Guid.NewGuid().ToString();
            OwnerId = Guid.NewGuid().ToString();
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}

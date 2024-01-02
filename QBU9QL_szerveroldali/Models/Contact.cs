using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBU9QL_szerveroldali.Models
{
    public class Contact
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public Rider Owner { get; set; }
        public Contact() 
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}

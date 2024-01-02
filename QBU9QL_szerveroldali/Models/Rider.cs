using System.ComponentModel.DataAnnotations;

namespace QBU9QL_szerveroldali.Models
{
    public class Rider
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Vehicle {  get; set; }
        public Rider() {
            Id = Guid.NewGuid().ToString();
        }
        
    }
}

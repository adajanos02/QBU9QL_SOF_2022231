using System.ComponentModel.DataAnnotations;

namespace QBU9QL_szerveroldali.Models
{
    public class Galery
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        

        [StringLength(100)]
        public string PhotoUrl { get; set; }
        public Galery()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

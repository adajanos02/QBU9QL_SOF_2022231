using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBU9QL_szerveroldali.Models
{
    public class Travel
    {
        [Key]
        public string Id { get; set; }
        
        public string StartingPoint { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        
        public string OwnerId { get; set; }
        [NotMapped]
        public virtual SiteUser Owner { get; set; }
        public Travel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Travel(string id, string start, string destination, int distance)
        {
            Id = Guid.NewGuid().ToString();
            OwnerId = id;
            StartingPoint = start;
            Destination = destination;
            Distance = distance;
        }

    }
}

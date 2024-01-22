using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QBU9QL_szerveroldali.Models
{
    public class SiteUser : IdentityUser
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        
        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}

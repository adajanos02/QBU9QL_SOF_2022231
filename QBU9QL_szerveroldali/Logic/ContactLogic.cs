using Microsoft.AspNetCore.Identity;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Logic
{
    public class ContactLogic : IContactLogic
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<SiteUser> _userManager;

        public ContactLogic(ApplicationDbContext ctx, UserManager<SiteUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public List<Contact> GetContacts(string userId)
        {
            return _ctx.Contacts.Where(c => c.OwnerId == userId).ToList();
        }

        public void AddContact(Contact contact, string ownerId)
        {
            contact.OwnerId = ownerId;

            var old = _ctx.Contacts.FirstOrDefault(t => t.Name == contact.Name && t.Id == contact.Id);
            if (old == null)
            {
                _ctx.Contacts.Add(contact);
                _ctx.SaveChanges();
            }
        }

        public void DeleteContact(string contactId, string ownerId)
        {
            var item = _ctx.Contacts.FirstOrDefault(t => t.Id == contactId);
            if (item != null && item.OwnerId == ownerId)
            {
                _ctx.Contacts.Remove(item);
                _ctx.SaveChanges();
            }
        }

    }
}

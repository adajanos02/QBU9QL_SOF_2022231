using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Logic
{
    public interface IContactLogic
    {

        List<Contact> GetContacts(string userId);
        void AddContact(Contact contact, string ownerId);
        void DeleteContact(string contactId, string ownerId);
    }
}

using Microsoft.AspNetCore.Identity;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Logic
{
    public class TravelLogic : ITravelLogic
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<SiteUser> _userManager;

        public TravelLogic(ApplicationDbContext context, UserManager<SiteUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        

        public IEnumerable<Travel> GetTravels(string ownerId)
        {
            return _context.Travels.ToList();
        }

        public void AddTravel(Travel travel, string ownerId)
        {
            travel.OwnerId = ownerId;

            var old = _context.Travels.FirstOrDefault(t => t.Destination == travel.Destination && t.OwnerId == travel.OwnerId);
            if (old == null)
            {
                _context.Travels.Add(travel);
                _context.SaveChanges();
            }
        }

        public void DeleteTravel(string travelId, string ownerId)
        {
            var item = _context.Travels.FirstOrDefault(t => t.Id == travelId);
            if (item != null && item.OwnerId == ownerId)
            {
                _context.Travels.Remove(item);
                _context.SaveChanges();
            }
        }
        public void AdminDeleteTravel(string travelId, string ownerId)
        {
            var item = _context.Travels.FirstOrDefault(t => t.Id == travelId);
            if (item != null)
            {
                _context.Travels.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}

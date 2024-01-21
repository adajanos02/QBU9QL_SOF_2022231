using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Logic
{
    public interface ITravelLogic
    {
        IEnumerable<Travel> GetTravels(string ownerId);
        void AddTravel(Travel travel, string ownerId);
        void DeleteTravel(string travelId, string ownerId);
    }
}

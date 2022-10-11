using EventAPIMySQL.Models;

namespace EventAPIMySQL.Interfaces
{
    public interface IEventRepository
    {
        ICollection<Event> GetEvents();
        Event GetEvent(int eventId);
        bool EventExists(int eventId);
        bool CreateEvent(Event eventObj);
        bool UpdateEvent(Event eventObj);
        bool DeleteEvent(Event eventObj);
        bool Save();

    }
}

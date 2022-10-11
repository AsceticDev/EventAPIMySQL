using EventAPIMySQL.Data;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEvent(Event eventObj)
        {
            _context.Add(eventObj);
            return Save();
        }

        public bool DeleteEvent(Event eventObj)
        {
            _context.Remove(eventObj);
            return Save();
        }

        public bool EventExists(int eventId)
        {
            return _context.Events
                .Any(e => e.Id == eventId);
        }

        public Event GetEvent(int eventId)
        {
            return _context.Events
                .Where(e => e.Id == eventId)
                .FirstOrDefault();
        }

        public ICollection<Event> GetEvents()
        {
            return _context.Events
                .OrderBy(e => e.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEvent(Event eventObj)
        {
            throw new NotImplementedException();
        }
    }
}

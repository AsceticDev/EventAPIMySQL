using EventAPIMySQL.Data;
using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Guest;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAPIMySQL.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DataContext _context;

        public GuestRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Guest> GetGuests()
        {
            return _context.Guests
                .OrderBy(g => g.Id)
                .Include(g=>g.GuestAllergies).ThenInclude(ga=>ga.Allergy)
                .Include(g=>g.GuestEvents).ThenInclude(ge=>ge.Event)
                .ToList();
        }
        public Guest GetGuest(int guestId)
        {
            var guestDb = _context.Guests.Where(g => g.Id == guestId).FirstOrDefault();

            return _context.Guests
                .Where(g => g.Id == guestId)
                .Include(g => g.GuestAllergies).ThenInclude(g => g.Allergy)
                .Include(g=>g.GuestEvents).ThenInclude(ge=>ge.Event)
                .FirstOrDefault();
        }

        public Guest GetGuest(string lastName)
        {
            return _context.Guests
                .Where(g => g.LastName == lastName)
                .FirstOrDefault(); 
        }

        public bool GuestExists(int guestId)
        {
            return _context.Guests
                .Any(g => g.Id == guestId);
        }

        public bool CreateGuest(Guest guest)
        {

            //if(guest.allergies)
            //var allergy = _context.Allergies.Where(g => g.Id == allergyId).FirstOrDefault();
            //var eventO = _context.Events.Where(g => g.Id == eventId).FirstOrDefault();

            //if (allergy != null)
            //{
            //    var guestAllergy = new GuestAllergy()
            //    {
            //        Allergy = allergy,
            //        Guest = guest,
            //    };

            //    _context.Add(guestAllergy);
            //}
            //if (eventO != null)
            //{

            //    var eventGuest = new EventGuest()
            //    {
            //        Event = eventO,
            //        Guest = guest,
            //    };

            //    _context.Add(eventGuest);
            //}

            _context.Add(guest);
            return Save();
        }
        public bool UpdateGuest(Guest guest)
        {
            _context.Update(guest);
            return Save();
        }
        
        public bool DeleteGuest(Guest guest)
        {
            _context.Remove(guest);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Guest> GetGuestByAllergy(string allergyType)
        {
            return _context.GuestAllergies
                .Where(a => a.Allergy.AllergyType == allergyType)
                .Select(g => g.Guest)
                .ToList();
        }

        public ICollection<Guest> GetGuestByEvent(int eventId)
        {
            return _context.GuestEvents.Where(a => a.Event.Id == eventId).Select(g => g.Guest).ToList();
        }

        public Guest GetGuestByEmailTrimToUpper(CreateGuestDto guestCreate)
        {
            return GetGuests().Where(c => c.Email.Trim().ToUpper() == guestCreate.Email.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool AddAllergiesToGuest(int guestId, List<CreateAllergyDto> allergies)
        {
            //
            var guestDb = _context.Guests.Where(g=>g.Id == guestId).FirstOrDefault();
            foreach(CreateAllergyDto allergy in allergies)
            {
                var allergyDb = _context.Allergies.Where(a => a.AllergyType == allergy.AllergyType).FirstOrDefault();
                Console.WriteLine($"Allergy ID: {allergyDb.Id}, Allergy Type: {allergyDb.AllergyType}");

                if (allergyDb != null && guestDb != null)
                {
                    Console.WriteLine("####################");
                    Console.WriteLine("We inside not null");
                    GuestAllergy gaItem = new GuestAllergy()
                    {
                        AllergyId = allergyDb.Id,
                        GuestId = guestDb.Id
                    };
                    _context.GuestAllergies.Add(gaItem);
                }
                else
                {
                    Console.WriteLine("DB var is null!!");
                    Console.WriteLine("guestId: " + guestId);
                    return false;
                }
            }
            return Save();
        }


    }
}

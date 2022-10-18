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

        public ICollection<Guest> GetGuestsByAllergy(string allergyType)
        {
            return _context.GuestAllergies
                .Where(a => a.Allergy.AllergyType == allergyType)
                .Select(g => g.Guest)
                .ToList();
        }

        public ICollection<Guest> GetGuestsByEvent(int eventId)
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
            var guestDb = _context.Guests.Where(g => g.Id == guestId).FirstOrDefault();
            foreach (CreateAllergyDto allergy in allergies)
            {
                var allergyDb = _context.Allergies.Where(a => a.AllergyType == allergy.AllergyType).FirstOrDefault();

                if (allergyDb != null && guestDb != null)
                {
                    GuestAllergy gaItem = new GuestAllergy()
                    {
                        AllergyId = allergyDb.Id,
                        GuestId = guestDb.Id
                    };
                    _context.GuestAllergies.Add(gaItem);
                }
                else return false;
            }
            return Save();
        }

        public bool UpdateGuestAllergies(UpdateGuestDto updatedGuest, List<UpdateAllergyDto> allergyListToAdd, List<UpdateAllergyDto> allergyListToRemove)
        {

            List<GuestAllergy> guestAllergiesDb = _context.GuestAllergies.Where(ga=>ga.GuestId == updatedGuest.Id).ToList();

            if (updatedGuest.allergies == null || updatedGuest.allergies.Count() == 0) return false;
            if(!GuestExists(updatedGuest.Id))
            {
                Console.WriteLine($"Invalid Guest! ID: {updatedGuest.Id}");
                return false;
            }


            if (allergyListToAdd != null)
            {
                foreach (UpdateAllergyDto allergy in allergyListToAdd)
                {
                    var allergyDb = _context.Allergies.Where(a => a.AllergyType == allergy.AllergyType).FirstOrDefault();
                    bool allergyDbExists = _context.Allergies.Any(a => a.AllergyType == allergy.AllergyType);

                    //does the allergy exist? if so add the relationship between allergy-guest
                    if (!allergyDbExists)
                    {
                        Console.WriteLine($"Allergy {allergy.AllergyType} does not exist.");
                        return false;
                    }
                    if (allergyDb != null && guestAllergiesDb != null)
                    {
                        Console.WriteLine("allergyDb and guestAllergiesDb are not null");
                        GuestAllergy gaItem = new GuestAllergy()
                        {
                            AllergyId = allergy.Id,
                            GuestId = updatedGuest.Id
                        };
                        _context.GuestAllergies.Add(gaItem);
                    }
                    else return false;
                }
            }
            
            if (allergyListToRemove!= null)
            {
                foreach (UpdateAllergyDto allergy in allergyListToRemove)
                {
                    var allergyDb = _context.Allergies.Where(a => a.AllergyType == allergy.AllergyType).FirstOrDefault();
                    bool allergyDbExists = _context.Allergies.Any(a => a.AllergyType == allergy.AllergyType);

                    if (!allergyDbExists)
                    {
                        Console.WriteLine($"Allergy {allergy.AllergyType} does not exist.");
                        return false;
                    }

                    if (allergyDb != null && guestAllergiesDb != null)
                    {
                        Console.WriteLine("allergyDb and guestAllergiesDb are not null");
                        var gaItem = _context.GuestAllergies.Where(a=>a.GuestId == updatedGuest.Id && a.AllergyId == allergy.Id).FirstOrDefault();
                        if (gaItem != null)
                        {
                            _context.GuestAllergies.Remove(gaItem);
                        }
                        else return false;
                    }
                    else return false;
                }

            }

            return Save();
        }

    }
}

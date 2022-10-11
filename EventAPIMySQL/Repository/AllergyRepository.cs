using EventAPIMySQL.Data;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Repository
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly DataContext _context;

        public AllergyRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Allergy> GetAllergies()
        {
            return _context.Allergies
                .OrderBy(g => g.Id)
                .ToList();
        }

        public bool AllergyExists(int allergyId)
        {
            return _context.Allergies
                .Any(a => a.Id == allergyId);
        }
        public bool AllergyExists(string allergyType)
        {
            return _context.Allergies
                .Any(a => a.AllergyType == allergyType);
        }


        public bool CreateAllergy(Allergy allergy)
        {
            _context.Add(allergy);
            return Save();
        }

        public bool DeleteAllergy(int allergyId)
        {
            _context.Remove(allergyId);
            return Save();
        }

        public Allergy GetAllergy(int allergyId)
        {
            return _context.Allergies
                .Where(a => a.Id == allergyId)
                .FirstOrDefault();
        }

        public Allergy GetAllergy(string allergyType)
        {
            return _context.Allergies
                .Where(a => a.AllergyType == allergyType)
                .FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAllergy(Allergy allergy)
        {
            _context.Update(allergy);
            return Save();
        }

    }
}

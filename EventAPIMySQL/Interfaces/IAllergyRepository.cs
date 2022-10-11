using EventAPIMySQL.Models;

namespace EventAPIMySQL.Interfaces
{
    public interface IAllergyRepository
    {
        ICollection<Allergy> GetAllergies();
        Allergy GetAllergy(int allergyId);
        Allergy GetAllergy(string allergyType);
        bool AllergyExists(int allergyId);
        bool AllergyExists(string allergyType);
        bool CreateAllergy(Allergy allergy);
        bool UpdateAllergy(Allergy allergy);
        bool DeleteAllergy(int allergyId);
        bool Save();
    }
}

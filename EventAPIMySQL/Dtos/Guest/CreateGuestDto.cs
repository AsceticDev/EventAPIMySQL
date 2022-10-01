using EventAPIMySQL.Dtos.Allergy;
using Microsoft.EntityFrameworkCore;


namespace EventAPIMySQL.Dtos.Guest
{
    public class CreateGuestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        //optional, can have many
        public List<ReadAllergyDto> Allergies { get; set; } = new List<ReadAllergyDto>();

    }

    public static class CreateGuestDtoExtensions
    {
        public static Models.Guest ToGuestModel(this CreateGuestDto guest)
        {
            return new Models.Guest
            {
               FirstName = guest.FirstName,
               LastName = guest.LastName,
               Email = guest.Email,
               DateOfBirth = guest.DateOfBirth,
               Allergies = guest.Allergies.Select(a => a.ToAllergyModel()).ToList()
            };
        }
    }
}

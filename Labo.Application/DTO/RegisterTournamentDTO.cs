using System.ComponentModel.DataAnnotations;
using Labo.Domain.Enums;

namespace Labo.Application.DTO
{
    public class RegisterTournamentDTO
    {

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(400)]
        public string? Adress { get; set; }

        [Range(2, 32)]
        public int MinMembers { get; set; }

        [Range(2, 32)]
        public int MaxMembers { get; set; }

        [Range(0, 3000)]
        public int? MinElo { get; set; }

        [Range(0, 3000)]
        public int? MaxElo { get; set; }        

        public Categories Category { get; set; }        

        public bool WomenOnly { get; set; }
                
        public DateTime DeadlineDate { get; set; }                
    }
}

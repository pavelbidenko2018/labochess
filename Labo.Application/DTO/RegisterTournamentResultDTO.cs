using System.ComponentModel.DataAnnotations;
using Labo.Domain.Entities;
using Labo.Domain.Enums;

namespace Labo.Application.DTO
{
    public class RegisterTournamentResultDTO(Tournament t)
    {
        public int Id { get; set; }

        public string Name { get; set; } = t.Name;


        public string? Adress { get; set; } = t.Adress;

        
        public int MinMembers { get; set; } = t.MinMembers;

        
        public int MaxMembers { get; set; } = t.MaxMembers;

        
        public int? MinElo { get; set; } = t.MinElo;


        public int? MaxElo { get; set; } = t.MaxElo;

        public Categories Category { get; set; } = t.Category;        

        public bool WomenOnly { get; set; } = t.WomenOnly;

        public DateTime Created { get; set; } = t.CreationDate;

        public DateTime Updated { get; set; } = t.UpdateDate;

        public DateTime Deadline { get; set; } = t.DeadlineDate;              
    }
}

using System.ComponentModel.DataAnnotations;
using Labo.Domain.Entities;
using Labo.Domain.Enums;

namespace Labo.Application.DTO
{
    public class TournamentResultDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Adress { get; set; } = null!;

        public int MinMembers { get; set; }

        public int MaxMembers { get; set; }

        public int? MinElo { get; set; }

        public int? MaxElo { get; set; }

        public Categories[] Category { get; set; }

        public bool WomenOnly { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public DateTime Deadline { get; set; }
    }
}

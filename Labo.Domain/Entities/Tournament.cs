using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labo.Domain.Enums;

namespace Labo.Domain.Entities
{
    public class Tournament
    {
        public int Id { get; set;}

        public string Name { get; set; } = null!;

        public string? Adress { get; set; }

        public int MinMembers { get; set; }

        public int MaxMembers { get; set; }

        public int? MinElo { get; set;}

        public int? MaxElo { get; set;}

        public Categories Category { get; set;}

        public Status Status { get; set; }

        public int CurrentRound { get; set; }

        public bool WomenOnly { get; set; }

        public DateTime DeadlineDate { get; set;}

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}

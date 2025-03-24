using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using Labo.Application.DTO;
using Labo.Application.Interfaces.Repositories;
using Labo.Application.Interfaces.Services;
using Labo.Domain.Entities;
using Labo.Domain.Enums;

namespace Labo.Application.Services
{
    public class TournamentService(ITournamentRepository repository) : ITournamentService
    {
        public Tournament Register(RegisterTournamentDTO dto)
        {
            using TransactionScope transactionScope = new();

            Tournament t =  repository.Add(new Tournament
            {
                Name = dto.Name,
                Adress = dto.Adress,
                MinMembers = dto.MinMembers,
                MaxMembers = dto.MaxMembers,
                MinElo = dto.MinElo,
                MaxElo = dto.MaxElo,
                Category = dto.Category,

                Status = Status.Pending,
                CurrentRound = 0,

                WomenOnly = dto.WomenOnly,
                DeadlineDate = dto.DeadlineDate,

                CreationDate = DateTime.Now,

                UpdateDate = DateTime.Now

            });

            transactionScope.Complete();

            return t;
        }
    }
}

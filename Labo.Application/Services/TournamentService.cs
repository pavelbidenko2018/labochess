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
        public List<TournamentResultDTO> GetAll()
        {
            return repository.Find().Select(t => new TournamentResultDTO
            {
                Id = t.Id,
                Name = t.Name,
                Adress = t.Adress,
                MinMembers = t.MinMembers,
                MaxMembers = t.MaxMembers,
                MinElo = t.MinElo,
                MaxElo = t.MaxElo,
                Deadline = t.DeadlineDate,
                Created = t.CreationDate,
                Updated = t.UpdateDate,
                Category = t.Category,
                WomenOnly = t.WomenOnly,
            }
            ).ToList();            
        }

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
                DeadlineDate = dto.Deadline,

                CreationDate = DateTime.Now,

                UpdateDate = DateTime.Now

            });

            transactionScope.Complete();

            return t;
        }

        public bool RemoveBy(int id)
        {
            Tournament? t = repository.FindOneWhere(t => t.Id == id);
            if (t is null) {
                return false;
            }

            repository.Remove(t);

            return true;

        }
    }
}

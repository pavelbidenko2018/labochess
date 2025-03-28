using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using Labo.Application.DTO;
using Labo.Application.Exceptions;
using Labo.Application.Interfaces.Repositories;
using Labo.Application.Interfaces.Services;
using Labo.Domain.Entities;
using Labo.Domain.Enums;

namespace Labo.Application.Services
{
    public class TournamentService(ITournamentRepository repository) : ITournamentService
    {

        private object[] categories = new[] { 
            new {value = 1},
            new {value = 2},
            new {value = 4}
        };

        public List<TournamentResultDTO> GetAll()
        {
            return repository.Find().Select(t => convertFromTournament(t)
            ).ToList();            
        }

        public TournamentResultDTO GetById(int id)
        {
            Tournament? t = repository.FindOneWhere(t => t.Id == id);
            if (t is not null) {
                return convertFromTournament(t);
            }
            else throw new NotFoundException("Tournament");
            
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

        private Categories[] decodeCategories(int cat) {
                        

            List<Categories> selectedRoles = new();

            foreach (Categories category in Enum.GetValues(typeof(Categories)))
            {                
                if ((cat & (int)category) != 0)
                {
                    selectedRoles.Add(category);      
                }
            }
            return selectedRoles.ToArray();
        }

        private TournamentResultDTO convertFromTournament(Tournament t) {
            return new TournamentResultDTO
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
                Category = decodeCategories((int)t.Category),                
                WomenOnly = t.WomenOnly,
            };

        }
    }
}

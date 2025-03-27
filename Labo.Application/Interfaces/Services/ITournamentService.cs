using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labo.Application.DTO;
using Labo.Domain.Entities;

namespace Labo.Application.Interfaces.Services
{
    public interface ITournamentService
    {
        public Tournament Register(RegisterTournamentDTO dto);

        public List<TournamentResultDTO> GetAll();
        public bool RemoveBy(int id);
        public TournamentResultDTO GetById(int id);
    }
}

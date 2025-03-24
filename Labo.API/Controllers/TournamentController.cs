using Labo.Application.DTO;
using Labo.Application.Interfaces.Services;
using Labo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Labo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController(ITournamentService tournamentService) : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] RegisterTournamentDTO dto) { 
    
            Tournament t = tournamentService.Register(dto);

            return Created("tournament/" + t.Id, null);
        }


    }
}

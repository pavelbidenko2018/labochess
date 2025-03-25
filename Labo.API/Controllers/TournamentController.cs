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

            try
            {
                Tournament t = tournamentService.Register(dto);

                return Created("tournament/" + t.Id, new RegisterTournamentResultDTO(t));
            }
            catch (Exception e)
            {
               return Conflict(e.Message);                
            }
            
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
                List<TournamentResultDTO> result = tournamentService.GetAll();
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int Id)
        {
           bool result = tournamentService.RemoveBy(Id);           

           return result?Ok(result):NoContent();
        }
    }
}

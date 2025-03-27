using Labo.Application.DTO;
using Labo.Application.Exceptions;
using Labo.Application.Interfaces.Services;
using Labo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mail;

namespace Labo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMemberService memberService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RegisterMemberDTO dto)
        {
            try
            {
                Member m = memberService.Register(dto);
                return Created("member/" + m.Id, new RegisterMemberResultDTO(m));
            }
            catch (DuplicatePropertyException ex)
            {
                return Conflict(ex.Message);
            }
            catch (SmtpException)
            {
                return Problem("L'email n'a pas pu être envoyé");
            }
        }

        [HttpGet("exists")]
        public IActionResult CheckMember([FromQuery] string email)
        {         
            bool exists = memberService.CheckMember(email);

            // Return the result as a JSON object with the 'exists' boolean property
            return Ok(new { exists });                    
            
        }

    }
}

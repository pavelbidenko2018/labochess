using Labo.Application.DTO;
using Labo.Domain.Entities;

namespace Labo.Application.Interfaces.Services
{
    public interface IMemberService
    {
        public bool CheckMember(string email);
        public Member Register(RegisterMemberDTO dto);
    }
}

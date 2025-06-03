using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.API.DTO;
using Member.Domain.Interfaces.Repositories;
using Member.Domain.Models.Entities;
using Member.Domain.Models.Responses;

namespace Member.Domain.Interfaces.Services
{
    public interface IMemberService
    {
        Task<MemberResponse.MemberResponseDTO> AddMember(MemberRequest.MemberRequestDTO memberRequestDTO);
        Task<Members> GetMembersAsync(int id);
    }
}

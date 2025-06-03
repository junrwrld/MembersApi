using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.API.DTO;
using Member.Domain.Models.Entities;
using Member.Domain.Models.Responses;

namespace Member.Domain.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        Task<MemberResponse.MemberResponseDTO> AddMember(MemberRequest.MemberRequestDTO member);
        Task<Members> GetByIdAsync(int id);
    }
}

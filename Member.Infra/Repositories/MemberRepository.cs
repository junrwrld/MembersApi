using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Member.API.DTO;
using Member.Domain.Interfaces.Repositories;
using Member.Domain.Models.Entities;
using Member.Domain.Models.Responses;
using Member.Infrastructure.Data;

namespace Member.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly PostgreeDbContext _context;
        private readonly IMapper _mapper;

        public MemberRepository(PostgreeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberResponse.MemberResponseDTO> AddMember(MemberRequest.MemberRequestDTO member)
        {
            var memberEntity = _mapper.Map<Members>(member);

            await _context.Members.AddAsync(memberEntity);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<MemberResponse.MemberResponseDTO>(memberEntity);

            return response;
        }

        public async Task<Members> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

    }
}

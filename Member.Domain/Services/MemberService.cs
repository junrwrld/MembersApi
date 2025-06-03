using Member.API.DTO;
using Member.Domain.Interfaces;
using Member.Domain.Interfaces.Repositories;
using Member.Domain.Interfaces.Services;
using Member.Domain.Models.Entities;
using Member.Domain.Models.Responses;
using Member.Domain.Utils;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;


    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<MemberResponse.MemberResponseDTO> AddMember(MemberRequest.MemberRequestDTO member)
    {
        // aqui você pode adicionar validações, regras de negócio, etc
        var result = await _memberRepository.AddMember(member);
        return result;
    }

    public Task<Members> GetMembersAsync(int id)
    {
        return _memberRepository.GetByIdAsync(id);
    }

}
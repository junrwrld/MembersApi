using AutoMapper;
using Member.API.DTO;
using Member.Domain.Models.Entities;
using Member.Domain.Models.Enums;
using static Member.API.DTO.MemberRequest;
using static Member.Domain.Models.Responses.MemberResponse;

namespace Member.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MemberRequest.MemberRequestDTO, Members>()
             .ForMember(dest => dest.BirthDate,
                        opt => opt.MapFrom(src => DateTime.SpecifyKind(src.BirthDate, DateTimeKind.Utc)))
             .ForMember(dest => dest.Cargo,
                        opt => opt.MapFrom(src => Enum.Parse<Cargo>(src.Cargo)));



            CreateMap<Members, MemberResponseDTO>()
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo.ToString()));

            // Você também pode fazer o mapeamento de saída se quiser:
            // CreateMap<Members, MemberResponseDTO>();
        }
    }
}

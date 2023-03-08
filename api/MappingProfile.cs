using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IncidentForCreationDto, Incident>()
                .ForMember(m => m.Description, opt => opt.MapFrom(x => x.IncidentDescription));

            CreateMap<IncidentForCreationDto, Account>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.AccountName));

            CreateMap<IncidentForCreationDto, Contact>()
                .ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(x => x.LastName));
        }
    }
}

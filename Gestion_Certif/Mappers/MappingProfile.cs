// MappingProfile.cs
using AutoMapper;
using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserVM>()
            .ForMember(dest => dest.Departement, opt => opt.MapFrom(src => src.departement))
            .ForMember(dest => dest.DepartementId, opt => opt.MapFrom(src => src.DepartementId))
            .ReverseMap(); 

    }
}

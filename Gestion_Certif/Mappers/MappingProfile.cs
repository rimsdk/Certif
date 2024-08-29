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

        CreateMap<AllCertif, AllCertifVM>()
           .ForMember(dest => dest.CertifName, opt => opt.MapFrom(src => src.certifName))
           .ForMember(dest => dest.CertifUrl, opt => opt.MapFrom(src => src.certifUrl))
           .ForMember(dest => dest.DepartementId, opt => opt.MapFrom(src => src.DepartementId))
           .ForMember(dest => dest.CertifPictureUrl, opt => opt.MapFrom(src => src.CertifPictureUrl))
           .ReverseMap();

    }
}

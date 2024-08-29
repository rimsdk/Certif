using AutoMapper;
using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Mappers
{
    public class AllCertifProfile : Profile
    {
        public AllCertifProfile()
        {
            CreateMap<AllCertif, AllCertifVM>()
                .ReverseMap();
        }
    }
}

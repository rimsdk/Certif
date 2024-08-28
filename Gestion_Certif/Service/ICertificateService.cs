using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;
using static Gestion_Certif.ViewModels.AddCertificateVM;

namespace Gestion_Certif.Service
{
    public interface ICertificateService
    {
        Task<IEnumerable<AddCertificateVM>> GetAllCertif();
        Task<AddCertificateVM> GetById(int id);

        Task AddCertif(AddCertificateVM certificat);
        Task UpdateCertif(UpdateCertificateVM certificat);
        Task DeleteCertif(int id);
    }
}

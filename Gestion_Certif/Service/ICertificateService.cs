using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Service
{
    public interface ICertificateService
    {
        Task<IEnumerable<Certificat>> GetAllCertif();
        Task<Certificat> GetCertifById(int id);
        Task AddCertif(AddCertificateVM certificat);
        Task UpdateCertif(UpdateCertificateVM certificat);
        Task DeleteCertif(Certificat certificat);
    }
}

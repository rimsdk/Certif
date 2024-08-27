using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Repository
{
    public interface ICertificateRepository
    {
        Task <IEnumerable<Certificat>>GetAllCertif();
        Task <Certificat >GetCertifById(int id);
        Task AddCertif(Certificat certificat);
        Task UpdateCertif(Certificat certificat);
        Task DeleteCertif(Certificat certificat);
        Task<List<CertificateWithCollaboratorCountVM>> GetAllCollaboratorsAsync();
        Task<List<Certificat>> GetCertifsByDepartement(int departementId);

    }
}

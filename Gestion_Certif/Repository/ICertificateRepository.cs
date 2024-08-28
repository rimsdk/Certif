using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;
using static Gestion_Certif.ViewModels.AddCertificateVM;

namespace Gestion_Certif.Repository
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<AddCertificateVM>> GetAllCertif();
        Task <Certificat >GetCertifById(int id);
        Task<AddCertificateVM> GetById(int id);
        Task AddCertif(Certificat certificat);
        Task UpdateCertif(Certificat certificat);
        Task DeleteCertif(int id);
        Task<List<CertificateWithCollaboratorCountVM>> GetAllCollaboratorsAsync();
        Task<List<Certificat>> GetCertifsByDepartement(int departementId);

        Task<List<CertificateData>> GetCertificatesWithMostApprovalsAsync();

    }
}

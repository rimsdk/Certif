using Gestion_Certif.Model;

namespace Gestion_Certif.Repository
{
    public interface IAllCertifRepository
    {
        Task<IEnumerable<AllCertif>> GetByDepartementIdAsync(int departementId);
        Task<IEnumerable<AllCertif>> GetAllAsync();
        Task<AllCertif> GetByIdAsync(int id);
        Task AddAsync(AllCertif certif);
        Task UpdateAsync(AllCertif certif);
        Task DeleteAsync(AllCertif certif);
    }
}

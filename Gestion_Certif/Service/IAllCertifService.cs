using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Service
{
    public interface IAllCertifService
    {
        Task<IEnumerable<AllCertifVM>> GetAllCertifsAsync();
        Task<AllCertifVM> GetCertifByIdAsync(int id);
        Task<AllCertifVM> CreateCertifAsync(AllCertifVM certifVM);
       // Task<bool> UpdateCertifAsync(AllCertifVM certifVM);
        Task<bool> DeleteCertifAsync(int id);
    }
}

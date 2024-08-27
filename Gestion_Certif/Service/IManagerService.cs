using System.Threading.Tasks;
using Gestion_Certif.Model;
using Gestion_Certif.ViewModels; 

namespace Gestion_Certif.Service
{
    public interface IManagerService
    {
        Task AddAsync(AddUserVM addUserVM);
        Task UpdateAsync(UpdateUserVM updateUserVM);
        Task DeleteAsync(DeleteUserVM deleteUserVM);
        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> GetByIdAsync(int id);
        Task<IEnumerable<Manager>> GetManagersByDepartementAsync(int departementId);
    }
}

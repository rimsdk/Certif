using Gestion_Certif.Model;

namespace Gestion_Certif.Repository
{
    public interface IManagerRepository {
        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> GetByIdAsync(int id);
        Task AddAsync(Manager manager);
        Task UpdateAsync(Manager manager);
        Task DeleteAsync(int id);
        Task<IEnumerable<Manager>> GetManagersByDepartementAsync(int departementId);
    }
}

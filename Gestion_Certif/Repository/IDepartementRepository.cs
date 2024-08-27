using System.Collections.Generic;
using System.Threading.Tasks;
using Gestion_Certif.Model;

namespace Gestion_Certif.Repositories
{
    public interface IDepartementRepository
    {
        Task<IEnumerable<Departement>> GetAllAsync();
        Task<Departement> GetByIdAsync(int id);
        Task AddAsync(Departement departement);
        Task UpdateAsync(Departement departement);
        Task DeleteAsync(int id);
    }
}

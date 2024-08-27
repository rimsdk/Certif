using System.Collections.Generic;
using System.Threading.Tasks;
using Gestion_Certif.Model;
using Gestion_Certif.Repositories;

namespace Gestion_Certif.Services
{
    public class DepartementService : IDepartementService
    {
        private readonly IDepartementRepository _repository;

        public DepartementService(IDepartementRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Departement>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Departement> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Departement departement)
        {
            await _repository.AddAsync(departement);
        }

        public async Task UpdateAsync(Departement departement)
        {
            await _repository.UpdateAsync(departement);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

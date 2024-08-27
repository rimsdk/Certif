using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Service
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repository;

        public ManagerService(IManagerRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Manager>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Manager> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(AddUserVM addManagerVM)
        {
            var manager = new Manager
            {
                username = addManagerVM.Username,
                password = addManagerVM.Password,
                email = addManagerVM.Email,
                role = addManagerVM.Role,
                DepartementId = addManagerVM.DepartementId ?? default,
  
                phoneNumer = addManagerVM.phoneNumer,
                Adress = addManagerVM.Adress
            };

            await _repository.AddAsync(manager);
        }

        public async Task UpdateAsync(UpdateUserVM updateManagerVM)
        {
            var manager = new Manager
            {
                id = updateManagerVM.Id,
                username = updateManagerVM.Username,
                password = updateManagerVM.Password,
                email = updateManagerVM.Email,
                role = updateManagerVM.Role,
                DepartementId = updateManagerVM.DepartementId ?? default
            };

            await _repository.UpdateAsync(manager);
        }
        public Task DeleteAsync(DeleteUserVM deleteManagerVM)
        {
            return _repository.DeleteAsync(deleteManagerVM.Id);
        }
        public async Task<IEnumerable<Manager>> GetManagersByDepartementAsync(int departementId)
        {
            return await _repository.GetManagersByDepartementAsync(departementId);
        }


    }
}

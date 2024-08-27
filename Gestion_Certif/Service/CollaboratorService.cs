using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.Services;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Service
{
    public class CollaborateurService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _repository;

        public CollaborateurService(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Collaborateur>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Collaborateur> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(AddUserVM addCollaborateurVM)
        {
            var collaborateur = new Collaborateur
            {
                username = addCollaborateurVM.Username,
                password = addCollaborateurVM.Password,
                email = addCollaborateurVM.Email,
                role = addCollaborateurVM.Role,
                DepartementId = addCollaborateurVM.DepartementId ?? default
            };

            await _repository.AddAsync(collaborateur);
        }

        public async Task UpdateAsync(UpdateUserVM updateCollaborateurVM)
        {
            var collaborateur = new Collaborateur
            {
                id = updateCollaborateurVM.Id,
                username = updateCollaborateurVM.Username,
                password = updateCollaborateurVM.Password,
                email = updateCollaborateurVM.Email,
                role = updateCollaborateurVM.Role,
                DepartementId = updateCollaborateurVM.DepartementId ?? default
            };

            await _repository.UpdateAsync(collaborateur);
        }
        public Task DeleteAsync(DeleteUserVM deleteCollaborateurVM)
        {
            return _repository.DeleteAsync(deleteCollaborateurVM.Id);
        }
        public Task<IEnumerable<Collaborateur>> GetCollaborateursByDepartementAsync(int departementId)
        {
            return _repository.GetCollaborateursByDepartementAsync(departementId);
        }
        public Task<IEnumerable<Collaborateur>> GetByUsernameAsync(string username)
        {
            return _repository.GetByUsernameAsync(username);
        }


    }

}

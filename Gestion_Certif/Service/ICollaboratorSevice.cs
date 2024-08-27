using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Services
{
    public interface ICollaboratorService
    {

        Task<IEnumerable<Collaborateur>> GetAllAsync();
        Task<Collaborateur> GetByIdAsync(int id);
        Task AddAsync(AddUserVM addCollaborateurVM);
        Task UpdateAsync(UpdateUserVM updateCollaborateurVM);
        Task DeleteAsync(DeleteUserVM deleteCollaborateurVM);
        Task<IEnumerable<Collaborateur>> GetCollaborateursByDepartementAsync(int departementId);
        Task<IEnumerable<Collaborateur>> GetByUsernameAsync(string username);
    }
}
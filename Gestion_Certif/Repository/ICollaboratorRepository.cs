using Gestion_Certif.Model;

namespace Gestion_Certif.Repository
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborateur>> GetAllAsync();
        Task<Collaborateur> GetByIdAsync(int id);
        Task AddAsync(Collaborateur collaborateur);
        Task UpdateAsync(Collaborateur collaborateur);
        Task DeleteAsync(int id);
        Task<IEnumerable<Collaborateur>> GetCollaborateursByDepartementAsync(int departementId);
        Task<IEnumerable<Collaborateur>> GetByUsernameAsync(string username);
    }
}

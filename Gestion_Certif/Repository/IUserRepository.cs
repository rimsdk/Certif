using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;
using System.Collections.Generic;

namespace Gestion_Certif.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();

        Task<User>IsExisteAsync(AuthVM user);
    
        Task<IEnumerable<User>> GetUsersByDepartementAsync(int departementId);
        Task UpdateAsync(User user);

         Task<bool> DeleteByIdAsync(int id);


    }

}

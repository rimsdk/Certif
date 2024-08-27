// Services/IUserService.cs
using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

public interface IUserService
{
    Task<UserVM> GetByIdAsync(int id);
    Task<IEnumerable<UserVM>> GetAllAsync();
    Task<IEnumerable<User>> GetUserByDepartementAsync(int departementId);
    Task <string> GetUserPasswordAsync(AuthVM uservm);
    Task<User> IsExistAsync(AuthVM uservm);
    Task<string> UploadProfilePictureAsync(int userId, IFormFile file);
    Task UpdateUserAsync(int id, PutUserVM putUserVM);

    Task<bool> DeleteUserByIdAsync(int id);


}

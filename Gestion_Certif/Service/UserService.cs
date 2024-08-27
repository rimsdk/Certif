// Services/UserService.cs
using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.ViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;

        _httpContextAccessor = httpContextAccessor;

    }

    public async Task<UserVM> GetByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id) as Collaborateur; 
        if (user == null) return null;
        return new UserVM

        {
            username = user.username,
            password = user.password,
            email = user.email,
            role = user.role,
            DepartementId = user.DepartementId,
            Departement = user.departement,
            phoneNumer = user.phoneNumer,
            Adress = user.Adress


        };
    }
    public async Task<IEnumerable<UserVM>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        var request = _httpContextAccessor.HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";

        return users.OfType<Collaborateur>().Select(user => new UserVM
        {
            username = user.username,
            password = user.password,
            email = user.email,
            role = user.role,
            DepartementId = user.DepartementId,
            Departement = user.departement,
            ProfilePictureUrl = string.IsNullOrEmpty(user.ProfilePictureUrl) ? null : $"{baseUrl}{user.ProfilePictureUrl}",
            phoneNumer = user.phoneNumer,
            Adress = user.Adress
        });
    }




    public async Task<IEnumerable<User>> GetUserByDepartementAsync(int departementId)
    {
        return await _repository.GetUsersByDepartementAsync(departementId);
    }

    public async Task<string> GetUserPasswordAsync(AuthVM uservm)
    {
        var user_Pass = await _repository.IsExisteAsync(uservm);
            
        return user_Pass.password;
    }

    public async Task<User> IsExistAsync(AuthVM uservm)
    {
       
        User user_Exist = await _repository.IsExisteAsync(uservm);
        if (user_Exist != null)
        {
            return user_Exist;
        }
       
        return null;
    }
    public async Task<string> UploadProfilePictureAsync(int userId, IFormFile file)
    {
        if (file == null)
            throw new ArgumentNullException(nameof(file), "No file uploaded");

        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        // Générer un nom de fichier unique
        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var user = await _repository.GetUserByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException("User not found");

        // Stocker l'URL relative
        var relativeUrl = $"/images/{fileName}";
        user.ProfilePictureUrl = relativeUrl;
        await _repository.UpdateAsync(user);

        // Construire l'URL complète
        var request = _httpContextAccessor.HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";
        var imageUrl = $"{baseUrl}{relativeUrl}";

        return imageUrl;
    }

    public async Task<bool> DeleteUserByIdAsync(int id)
    {
        return await _repository.DeleteByIdAsync(id);
    }
    public async Task UpdateUserAsync(int id, PutUserVM putUserVM)
    {
        var existingUser = await _repository.GetUserByIdAsync(id);
        if (existingUser == null)
        {
            throw new Exception("User not found.");
        }

        existingUser.username = putUserVM.Username;
        existingUser.password = putUserVM.Password;
        existingUser.email = putUserVM.Email;
        existingUser.role = putUserVM.Role;
        existingUser.DepartementId = putUserVM.DepartementId ?? default;
        existingUser.phoneNumer = putUserVM.phoneNumer;
        existingUser.Adress = putUserVM.Adress;
        existingUser.ProfilePictureUrl = putUserVM.ProfilePictureUrl;

        await _repository.UpdateAsync(existingUser);
    }
}

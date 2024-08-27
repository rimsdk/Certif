using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    public UserController(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserVM>>> GetUsers()
    {
        var users = await _userRepository.GetAllAsync();

        if (users == null || !users.Any())
        {
            return NotFound();
        }

        return Ok(users);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound(); 
        }

        return Ok(user);
    }
    [HttpGet("exists")]
    public async Task<ActionResult<AuthVM>> CheckIfUserExists([FromQuery] string email)
    {
        var uservm = new AuthVM { email = email };
        var user = await _userRepository.IsExisteAsync(uservm);

        if (user != null)
        {
           

            return Ok(user); 
        }

        return NotFound(); 
    }
    [HttpPost("{userId}/profile-picture")]
    public async Task<IActionResult> UploadProfilePicture(int userId, IFormFile file)
    {
        try
        {
            var imageUrl = await _userService.UploadProfilePictureAsync(userId, file);
            return Ok(new { imageUrl });
        }
        catch (ArgumentNullException)
        {
            return BadRequest("No file uploaded");
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found");
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "An error occurred while processing your request");
        }
    }
    [HttpGet("users/{userId}/profile-picture")]
    public IActionResult GetUserProfilePicture(int userId)
    {
        var user = _userService.GetByIdAsync(userId).Result;
        if (user == null || string.IsNullOrEmpty(user.ProfilePictureUrl))
        {
            return NotFound("User or profile picture not found");
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.ProfilePictureUrl.TrimStart('/'));

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("Image not found");
        }

        var extension = Path.GetExtension(filePath).ToLowerInvariant();
        string mimeType;

        // Détecter le type MIME en fonction de l'extension
        switch (extension)
        {
            case ".jpg":
            case ".jpeg":
                mimeType = "image/jpeg";
                break;
            case ".png":
                mimeType = "image/png";
                break;
            case ".gif":
                mimeType = "image/gif";
                break;
            case ".bmp":
                mimeType = "image/bmp";
                break;
            case ".webp":
                mimeType = "image/webp";
                break;
            default:
                return BadRequest("Unsupported image format");
        }

        var image = System.IO.File.OpenRead(filePath);
        return File(image, mimeType);
    }

    [HttpGet("departement/{departementId}")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersByDepartement(int departementId)
 
   {
        var users = await _userService.GetUserByDepartementAsync(departementId);
        if (users == null || !users.Any())
        {
            return NotFound();
        }
        return Ok(users);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, [FromBody] PutUserVM putUserVM)
    {
        try
        {
            await _userService.UpdateUserAsync(id, putUserVM);
            return Ok(new { message = "User updated successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _userService.DeleteUserByIdAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }



}

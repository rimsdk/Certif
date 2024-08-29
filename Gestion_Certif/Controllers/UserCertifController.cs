using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCertifController : ControllerBase
    {
        private readonly MyContext _context;

        public UserCertifController(MyContext context)
        {
            _context = context;
        }

        // GET: api/UserCertif/User/5
        // GET: api/UserCertif/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Certificat>>> GetUserCertifs(int userId)
        {
            // Check if the user exists
            var user = await _context.Users
                .Include(u => u.departement)
                .FirstOrDefaultAsync(u => u.id == userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Get certificates directly associated with the user
            var userCertifs = await _context.Certificats
            .Where(c => c.userId == userId)
     .Select(c => new CertificateDTO
     {
         Id = c.id,
         CertifName = c.certifName,
         CertifPictureUrl = c.CertifPictureUrl,
         AchievementDate = c.achievementDate,
         DepartmentName = c.departement.name
     })
     .ToListAsync();


            if (userCertifs == null || !userCertifs.Any())
            {
                return NotFound("No certificates found for the user.");
            }

            return Ok(userCertifs);
        }

    }
}

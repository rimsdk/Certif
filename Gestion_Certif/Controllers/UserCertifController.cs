using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Certif.Model;

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
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<AllCertif>>> GetUserCertifs(int userId)
        {
            // Get the user and their department
            var user = await _context.Users
                .Include(u => u.departement)
                .FirstOrDefaultAsync(u => u.id == userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var departmentId = user.DepartementId;

            // Get certificates for the department
            var userCertifs = await _context.AllCertifs
                .Where(c => c.DepartementId == departmentId)
                .ToListAsync();

            if (userCertifs == null || !userCertifs.Any())
            {
                return NotFound("No certificates found for the department.");
            }

            return Ok(userCertifs);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Gestion_Certif.Services;
using Gestion_Certif.ViewModels;
using Gestion_Certif.Model;
using Gestion_Certif.Service;

namespace Gestion_Certif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaborateurController : ControllerBase
    {
        private readonly ICollaboratorService _service;

        public CollaborateurController(ICollaboratorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collaborateur>>> GetCollaborateurs()
        {
            var collaborateurs = await _service.GetAllAsync();
            return Ok(collaborateurs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collaborateur>> GetCollaborateur(int id)
        {
            var collaborateur = await _service.GetByIdAsync(id);
            if (collaborateur == null)
            {
                return NotFound();
            }
            return Ok(collaborateur);
        }

        [HttpPost]
        public async Task<ActionResult> PostCollaborateur(AddUserVM addCollaborateurVM)
        {
            await _service.AddAsync(addCollaborateurVM);
            return CreatedAtAction(nameof(GetCollaborateur), new { id = addCollaborateurVM.Id }, addCollaborateurVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollaborateur(int id, UpdateUserVM updateCollaborateurVM)
        {
            if (id != updateCollaborateurVM.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(updateCollaborateurVM);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborateur(int id)
        {
            await _service.DeleteAsync(new DeleteUserVM { Id = id });
            return NoContent();
        }
        [HttpGet("departement/{departementId}")]
        public async Task<ActionResult<IEnumerable<Collaborateur>>> GetCollaborateursByDepartement(int departementId)
        {
            var collaborateurs = await _service.GetCollaborateursByDepartementAsync(departementId);
            if (collaborateurs == null || !collaborateurs.Any())
            {
                return NotFound();
            }
            return Ok(collaborateurs);
        }
        [HttpGet("username/{username}")]
        public async Task<ActionResult<IEnumerable<Collaborateur>>> GetCollaborateursByUsername(string username)
        {
            var collaborateurs = await _service.GetByUsernameAsync(username);
            if (collaborateurs == null || !collaborateurs.Any())
            {
                return NotFound();
            }
            return Ok(collaborateurs);
        }
    }
}

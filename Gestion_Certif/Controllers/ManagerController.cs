using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestion_Certif.Service;
using Gestion_Certif.ViewModels;
using Gestion_Certif.Model;

namespace Gestion_Certif.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostManager([FromBody] AddUserVM addUserVM)
        {
            await _managerService.AddAsync(addUserVM);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutManager([FromBody] UpdateUserVM updateUserVM)
        {
            await _managerService.UpdateAsync(updateUserVM);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteManager([FromBody] DeleteUserVM deleteUserVM)
        {
            await _managerService.DeleteAsync(deleteUserVM);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetCollaborateurs()
        {
            var manager = await _managerService.GetAllAsync();
            return Ok(manager);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerVM>> GetManagerById(int id)
        {
            var manager = await _managerService.GetByIdAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            return Ok(manager);
        }
        [HttpGet("departement/{departementId}")]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagersByDepartement(int departementId)
        {
            var managers = await _managerService.GetManagersByDepartementAsync(departementId);
            if (managers == null || !managers.Any())
            {
                return NotFound();
            }
            return Ok(managers);
        }

    }
}

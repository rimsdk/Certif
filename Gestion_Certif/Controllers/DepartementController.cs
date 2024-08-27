using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestion_Certif.Model;
using Gestion_Certif.Services;

namespace Gestion_Certif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly IDepartementService _service;

        public DepartementsController(IDepartementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetAll()
        {
            var departements = await _service.GetAllAsync();
            return Ok(departements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departement>> GetById(int id)
        {
            var departement = await _service.GetByIdAsync(id);
            if (departement == null)
            {
                return NotFound();
            }
            return Ok(departement);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Departement departement)
        {
            await _service.AddAsync(departement);
            return CreatedAtAction(nameof(GetById), new { id = departement.id }, departement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Departement departement)
        {
            if (id != departement.id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(departement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

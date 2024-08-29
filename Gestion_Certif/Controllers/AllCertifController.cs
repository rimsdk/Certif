using Gestion_Certif.Service;
using Gestion_Certif.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Certif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllCertifController : ControllerBase
    {
        private readonly IAllCertifService _allCertifService;

        public AllCertifController(IAllCertifService allCertifService)
        {
            _allCertifService = allCertifService;
        }
        [HttpGet("by-departement")]
        public async Task<ActionResult<IEnumerable<AllCertifVM>>> GetCertifsByDepartement([FromQuery] int departementId, [FromQuery] string departementName)
        {
           

            var certifs = await _allCertifService.GetCertifsByDepartementAsync(departementId);
            return Ok(certifs);
        }

        
    
    [HttpGet]
        public async Task<ActionResult<IEnumerable<AllCertifVM>>> GetAllCertifs()
        {
            var certifs = await _allCertifService.GetAllCertifsAsync();
            return Ok(certifs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AllCertifVM>> GetCertifById(int id)
        {
            var certif = await _allCertifService.GetCertifByIdAsync(id);
            if (certif == null)
            {
                return NotFound();
            }
            return Ok(certif);
        }

        [HttpPost]
        public async Task<ActionResult<AllCertifVM>> CreateCertif([FromBody] AllCertifVM certifDto)
        {
            var createdCertif = await _allCertifService.CreateCertifAsync(certifDto);
            return CreatedAtAction(nameof(GetCertifById), new { id = createdCertif.Id }, createdCertif);
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCertif(int id, [FromBody] AllCertifVM certifDto)
        //{
        //    if (id != certifDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _allCertifService.UpdateCertifAsync(certifDto);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertif(int id)
        {
            var result = await _allCertifService.DeleteCertifAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}

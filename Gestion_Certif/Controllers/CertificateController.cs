using Gestion_Certif.Mappers;
using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.Service;
using Gestion_Certif.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//nihal
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_Certif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;
       
         

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
          
        }

        // GET: api/Certificate
        [HttpGet]
        public async Task<ActionResult> GetCertificats()
        {
            var certificates =  await _certificateService.GetAllCertif();
            return Ok(certificates);
        }

        //2eme
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCertificateCount()
        {
            var count = (await _certificateService.GetAllCertif()).Count();
            return Ok(count);
        }
        /*

        //Get all  Certifs m3a count coalbs 
        [HttpGet("all-collaborators")]
        public async Task<ActionResult<List<User>>> GetAllCollaborators()
        {
            var collaborators = await _certificateService.GetAllCollaboratorsAsync();
            if (collaborators == null || !collaborators.Any())
                return NotFound("No collaborators found.");

            return Ok(collaborators);
        }*/

        // GET api/Certificate/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCertificat(int id)
        {
            var certificat = await _certificateService.GetCertifById(id);
            if (certificat == null)
            {
                return NotFound();
            }
            var viewModel =   CertificateMapper.ToViewModel(certificat);
            return Ok(viewModel);
        }

        // POST api/Certificate
        [HttpPost]
        public async Task<ActionResult> PostCertificat([FromBody] AddCertificateVM addCertificateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            //var certificat = CertificateMapper.ToModel(addCertificateVM);
            await _certificateService.AddCertif(addCertificateVM);
            return CreatedAtAction("GetCertificat", new { id = addCertificateVM.Id }, addCertificateVM);
        }

        // PUT api/Certificate/5
        [HttpPut("{id}")]
        public IActionResult PutCertificat(int id, [FromBody] UpdateCertificateVM updateCertificateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid data or mismatched ID.", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            if (id != updateCertificateVM.id)
            {
                return BadRequest(new { Message = "ID in URL does not match ID in body." });
            }

            var existingCertificat = _certificateService.GetCertifById(id);
            if (existingCertificat == null)
            {
                return NotFound(new { Message = "Certificat not found." });
            }

            

            _certificateService.UpdateCertif(updateCertificateVM);
            return Ok(new { Message = "The update was successful." });
        }

        // DELETE api/Certificate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCertificat(int id)
        {
            var certificat = await  _certificateService.GetCertifById(id);
            if (certificat == null)
            {
                return NotFound(new { Message = "Certificat not found." });
            }

              await _certificateService.DeleteCertif(certificat);
            return Ok(new { Message = "Certificat deleted successfully." });
        }


    }
}


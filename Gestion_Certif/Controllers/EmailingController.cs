using Gestion_Certif.Service.EmailService;
using Gestion_Certif.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Certif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailingController : ControllerBase
    {

        private  readonly IEmailService _emailService;

        public EmailingController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("SendEmail")]
        public  IActionResult SendEmail(string emailVM)
        {
            _emailService.SendEmail(emailVM);
            return Ok("The  email  has  been  send !! ");
        }

        [HttpPost ("VerifierCode")]
        public IActionResult VerifierCode (string code)
        {
            if (_emailService.VerifyCode(code))
            {
                return Ok("the code  is correct !!!");
            }
            return BadRequest("The  code  is  not  identique ");
        }

        
    }
}

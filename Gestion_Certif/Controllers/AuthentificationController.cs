using Gestion_Certif.Mappers;
using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.Security;
using Gestion_Certif.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gestion_Certif.Controllers
{
    [Route("Authentificate")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly TokenGeneraterr _tokenGenerator;

        public AuthentificationController(IUserService userService, TokenGeneraterr tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;

        }

        [HttpPost("login")]

        public async Task<ActionResult> Login([FromBody] AuthVM user)
        {

            if (user == null)
            {
                return BadRequest("User data is missing.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                User existingUser = await _userService.IsExistAsync(user);
                if (existingUser == null)
                {
                    return BadRequest("An error occurred while trying to connect.");
                }
                else if (user.password != existingUser.password)
                {
                    return BadRequest("An error occurred while trying to connect.");
                }

                string token = _tokenGenerator.CreateTooken(existingUser);

                return Ok(token);
            }
            catch (NotImplementedException nie)
            {

                return StatusCode(StatusCodes.Status501NotImplemented, nie.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}

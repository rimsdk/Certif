using Gestion_Certif.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gestion_Certif.Security
{
    public class TokenGeneraterr
    {
        private readonly IConfiguration _configuration;
        public TokenGeneraterr(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        public string CreateTooken(User user)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Hash,user.password)};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration
                .GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,

                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }
}


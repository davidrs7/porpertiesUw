using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using properties.core.entities;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace properties.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetToken(UserLogin UserLogin)
        {
            if (validUser(UserLogin))
            {
                var Token = generateToken();
                return Ok(new { Token });
            }
            else
            {
                return NotFound();
            }          
        }

        private bool validUser(UserLogin Login) {
            return true;
        }

        private string generateToken() {

            var _SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:secretKey"]));
            var signinCredentials = new SigningCredentials(_SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signinCredentials);
            //claims

            var claims = new[] {

                new Claim(ClaimTypes.Name,"David Rodriguez"),
                new Claim(ClaimTypes.Email,"david@mail.com"),
                new Claim(ClaimTypes.Role,"Admin"),

            };

            //payload
            var payload = new JwtPayload
            (
                 _configuration["Authentication:Issuer"],
                 _configuration["Authentication:Audience"],
                 claims,
                 System.DateTime.Now,
                 System.DateTime.UtcNow.AddMinutes(2)
            );

            //signature

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

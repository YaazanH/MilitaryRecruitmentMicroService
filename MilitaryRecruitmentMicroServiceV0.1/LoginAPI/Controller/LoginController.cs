using LoginAPI.Models;
using LoginAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LoginAPI.Controller
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly LoginContext _context;

        public LoginController(IConfiguration config,LoginContext context)
        {
            _config = config;
            _context=context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login userLogin)
        {
            var User = Authenticate(userLogin);
            if (User != null)
            {
                var token = Generate(User);
                return Ok(token);

            }
            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult SignUp([FromBody] Login userLogin)
        {
            var User = Authenticate(userLogin);
            if (User == null)
            {
                _context.Add(userLogin);
                _context.SaveChanges();
                var token = Generate(userLogin);
                return Ok(token);

            }
            return NotFound("you have to change Username");

            
            
              
        }
        private string Generate(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {     
                new Claim(ClaimTypes.PrimarySid,user.ID.ToString())                
            };
            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Login Authenticate(Login userLogin)
        {
            var currentUser = _context.LoginDBS.Where(o => o.Username.ToLower() == userLogin.Username.ToLower() && o.password == userLogin.password).ToList();

            if (currentUser != null)
            {
                Login us = new Login { password = currentUser[0].password, ID = currentUser[0].ID, Username = currentUser[0].Username };
                return us;
            }
            return null;
        }
    }
}

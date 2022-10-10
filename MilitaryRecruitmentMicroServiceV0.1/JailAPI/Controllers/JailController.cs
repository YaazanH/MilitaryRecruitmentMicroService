using Microsoft.AspNetCore.Mvc;
using JailAPI.Models;
using JailAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;

namespace JailAPI.Controllers
{
    [ApiController]
    [Route("Jail")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class JailController : Controller
    {
        private readonly JailContext _context;
        public JailController(JailContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetUser/")]
        public ActionResult<Jail> GetIsPermit(int id)
        {
            var Person = _context.JailDBS.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person;
        }

    }
}

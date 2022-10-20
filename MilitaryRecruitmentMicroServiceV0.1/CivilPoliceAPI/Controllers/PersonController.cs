using CivilPoliceAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace CivilPoliceAPI.Controllers
{
    [ApiController]
    [Route("CivilPolice")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonController : Controller
    {
        private readonly CivilPoliceContext _context;

        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }

        public PersonController(CivilPoliceContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("NumberOfBrothers/")]
        public ActionResult<int> GetNumberOfBrothers()
        {
            int id = GetCurrentUserID();
            var person = _context.CivilPoliceDb.Where(x => x.id == id).FirstOrDefault();
            if (person == null) return NotFound();
            return person.NumberOfBrothers;
        }
    }
}

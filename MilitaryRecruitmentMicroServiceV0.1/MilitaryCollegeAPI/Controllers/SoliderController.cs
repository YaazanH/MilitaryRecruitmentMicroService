using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilitaryCollegeAPI.Data;
using System;
using System.Linq;
using System.Security.Claims;

namespace MilitaryCollegeAPI.Controllers
{
    [ApiController]
    [Route("MilitiryCollege")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SoliderController : Controller
    {
        private readonly MilitaryCollegeContext _context;

        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }

        public SoliderController(MilitaryCollegeContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetHasFired/")]
        public ActionResult<bool> GetHasFired(int id)
        {
            var solider = _context.MilitaryCollegeDb.Where(x => x.id == id).FirstOrDefault();
            if (solider == null) return NotFound();
          
            return solider.GotFired;
        }

    }
}

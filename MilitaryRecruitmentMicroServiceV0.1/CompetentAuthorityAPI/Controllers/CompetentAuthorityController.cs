using Microsoft.AspNetCore.Mvc;
using CompetentAuthorityAPI.Models;
using CompetentAuthorityAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;

namespace CompetentAuthorityAPI.Controllers
{
    [ApiController]
    [Route("CompetentAuthority")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompetentAuthorityController : Controller
    {
        private readonly CompetentAuthorityContext _context;
        public CompetentAuthorityController(CompetentAuthorityContext context)
        {
            _context = context;
        }

        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }


        [HttpGet]
        [Route("GetEntryDate/")]
        public ActionResult<DateTimeOffset> GetIsPermit()
        {
            int id= GetCurrentUserID();
            var Person = _context.CompetentAuthorityDBS.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.EntryDate;
        }

    }
}

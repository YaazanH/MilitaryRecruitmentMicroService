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
        [Route("GetIfInJail/")]
        public ActionResult<bool> GetIfInJail()
        {
            int id = GetCurrentUserID();
            var Person = _context.JailDBS.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            DateTime x = DateTime.Now;
            if (x > Person.ReleasDate)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("Period/")]
        public ActionResult<int> Period()
        {
            int id=GetCurrentUserID();
            var Person = _context.JailDBS.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            int ReleasYear =Person.ReleasDate.Year;
            int EntryYear = Person.EntryDate.Year;
            int x = ReleasYear - EntryYear;
            if (x>0)
            {
                return x;
            }
            return 0;


        }



    }
}

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
        public ActionResult<DateTime> Period()
        {
            int id=GetCurrentUserID();
            var Person = _context.JailDBS.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();

            int year = Person.ReleasDate.Year - Person.EntryDate.Year;
            int month = Person.ReleasDate.Month - Person.EntryDate.Month;
            int day = Person.ReleasDate.Day - Person.EntryDate.Day;
            DateTime x = new DateTime(year, month, day);
            return x;

        }



    }
}

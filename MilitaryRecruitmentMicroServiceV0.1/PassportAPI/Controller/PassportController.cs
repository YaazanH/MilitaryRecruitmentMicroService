using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassportAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PassportAPI.Controller
{
    [ApiController]
    [Route("Passport")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PassportController : ControllerBase
    {

        private readonly PassportContext _context;

        public PassportController(PassportContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIstravel/")]
        public ActionResult<bool> GetIsPermit()
        {
            int id = GetCurrentUserID();
            var Person = _context.PassportDBS.Where(x => x.UserID == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.Istravel;
        }

        [HttpGet]
        [Route("GetNumberOfDaysInSideCoun/")]
        public ActionResult<int> GetNumberOfDaysInSideCoun()
        {

            int id = GetCurrentUserID();
            var person = _context.PassportDBS.Where(x => x.UserID == id).FirstOrDefault();
            if (person == null) return NotFound();
            return person.NumberOfDaysInSideCoun;
        }

        [HttpGet]
        [Route("GetNumberOfDaysOutsideCoun/")]
        public ActionResult<int> GetNumberOfDaysOutsideCoun()
        {

            int id = GetCurrentUserID();
            var person = _context.PassportDBS.Where(x => x.UserID == id).FirstOrDefault();
            if (person == null) return NotFound();
            return person.NumberOfDaysOutsideCoun;
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
    }
}

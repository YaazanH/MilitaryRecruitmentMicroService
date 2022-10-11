using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using UniversityAPI.Data;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("University")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MasterConfirmationController : Controller
    {
        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }
        private readonly UniversityContext _context;

        public MasterConfirmationController(UniversityContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("HasMasterConfirmation/")]
        public ActionResult<bool> GetHasMasterConfirmation()
        {
            int id = GetCurrentUserID();
            var student = _context.UniversityDb.Where(x => x.id == id).FirstOrDefault();
            if (student == null) return NotFound();

            return student.HasMasterConfirmation;
        }

        [HttpGet]
        [Route("GetStudyYears/")]
        public ActionResult<int> GetStudyYears()
        {
            int id = GetCurrentUserID();
            var student = _context.UniversityDb.Where(x => x.id == id).FirstOrDefault();
            if (student == null) return NotFound();

            return student.YearsOfStudy;
        }
    }
}

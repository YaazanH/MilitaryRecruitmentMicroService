using DoctorsSyndicateAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace DoctorsSyndicateAPI.Controllers
{

    [ApiController]
    [Route("DoctorsSyndicate")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClinicConfirmationController : Controller
    {
        private readonly DoctorsSyndicateContext _context;
        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }

        public ClinicConfirmationController(DoctorsSyndicateContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetClinicConfirmation/")]
        public ActionResult<bool> GetClinicConfirmation(int id)
        {
            var doctor = _context.DoctorsSyndicateDb.Where(x => x.id == id).FirstOrDefault();
            if (doctor == null) return NotFound();
       
            return doctor.HasClinicConfirmation;
        }
    }
}

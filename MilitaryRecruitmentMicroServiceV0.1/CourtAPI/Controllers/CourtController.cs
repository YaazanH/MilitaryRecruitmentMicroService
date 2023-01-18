using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using CourtAPI.Data;
using CourtAPI.Models;

namespace CourtAPI.Controllers
{
    [ApiController]
    [Route("Court")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CourtController : Controller
    {
        private readonly CourtContext _context;

        public CourtController(CourtContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetYearsRemaining/")]
        public ActionResult<int> GetYearsRemaining()
        {
            int id = GetCurrentUserID();
            var item = _context.CourtDBS.Where(x => x.UserID == id).FirstOrDefault();
            if (item == null) return NotFound();
            int x = item.VerdictDate.Year + item.time;
            return x;
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

using AwqafAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace AwqafAPI.Controllers
{
    [ApiController]
    [Route("Awqaf")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AwqafController : Controller
    {


        private readonly AwqafContext _context;

        public AwqafController(AwqafContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIspermit/")]
        public ActionResult<bool> GetIsPermit()
        {
            int id = GetCurrentUserID();
            var Clerk = _context.AwqafDBS.Where(x => x.Id == id).FirstOrDefault();
            if (Clerk == null) return NotFound();
            return Clerk.Ispermit;
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


using DefenseAPI.Data;
using DefenseAPI.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using static DefenseAPI.Dtos;

namespace DefenseAPI.Controllers
{
    [ApiController]
    [Route("Defense")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DefenseController : Controller
    {
        private readonly DefenseContext _context;

        public DefenseController(DefenseContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetById/")]
        public ActionResult<DefenseDto> GetById()
        {
            int id = GetCurrentUserID();
            var Solder = _context.DefensesDBS.Where(x => x.id == id).FirstOrDefault();
            if (Solder == null) return NotFound();

            return Solder.AsDtos();

            
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

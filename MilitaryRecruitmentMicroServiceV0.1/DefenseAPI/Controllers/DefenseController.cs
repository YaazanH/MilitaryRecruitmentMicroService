using DefenseAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;


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
        public ActionResult<bool> GetById(int id)
        {
         
            var Solder = _context.DefensesDBS.Where(x => x.id == id).FirstOrDefault();
            if (Solder == null) return NotFound();

            return Solder.Isin;

            
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

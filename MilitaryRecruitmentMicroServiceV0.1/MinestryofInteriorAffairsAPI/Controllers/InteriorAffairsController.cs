using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinestryofInteriorAffairsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MinestryofInteriorAffairsAPI;
using Microsoft.AspNetCore.Authorization;

namespace MinestryofInteriorAffairs.Controllers
{

    [ApiController]
    [Route("MinestryofInteriorAffairs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InteriorAffairsController : Controller
    {


        private readonly MinestryofInteriorAffairsContext _context;

        public InteriorAffairsController(MinestryofInteriorAffairsContext context)
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
        [Route("GetIsDone/")]
        public ActionResult<bool> GetIsPermit()
        {
            int id = GetCurrentUserID();
            var person = _context.MinestryofInteriorAffairsDB.Where(x => x.UserID == id).FirstOrDefault();
            if (person == null) return NotFound();
            else {
                if (person.NumofYear >= 10)
                {
                    return true;
                }
                
            }
            return false;

        }
       
    }
}

using BarAssociationAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
namespace BarAssociationAPI.Controllers
{
    [ApiController]
    [Route("BarAssociationAPI")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BarAssociationController : Controller
    {
        private readonly BarAssociationContext _context;
        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }
        public BarAssociationController(BarAssociationContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetTrainProof/")]
        public ActionResult<bool> Gettrainproof()
        {
            int id = GetCurrentUserID();
            var Lawyer = _context.BarAssociationDB.Where(x => x.UserID == id).FirstOrDefault();
            if (Lawyer == null) return NotFound();
            DateTime after6monthsofgraduation = Lawyer.graduationDate.AddMonths(6);
            if (Lawyer.trainstartDate > after6monthsofgraduation) { return false; }
            return true;

        }


    }
}

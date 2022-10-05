using Microsoft.AspNetCore.Mvc;
using PoliticalPartiesAPI.Models;
using PoliticalPartiesAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System;

namespace PoliticalPartiesAPI.Controllers
{
    [ApiController]
    [Route("PoliticalParties")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PoliticalPartiesController : Controller
    {
        private readonly PoliticalPartiesContext _context;

        public PoliticalPartiesController(PoliticalPartiesContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker()
        {
            var id = GetCurrentUserID();
            var worker = _context.PoliticalPartiesDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.GetIsAWorker;
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

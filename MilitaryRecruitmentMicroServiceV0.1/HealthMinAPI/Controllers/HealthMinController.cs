using HealthMinAPI.Models;
using HealthMinAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace HealthMinAPI.Controllers
{
    [ApiController]
    [Route("HealthMin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class HealthMinController : Controller
    {
        private readonly HealthMinContext _context;

        public HealthMinController(HealthMinContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetHaveProb/")]
        public ActionResult<bool> GetHaveProb(int id)
        {
            //int id = GetCurrentUserID();
            var worker = _context.HealthMinDBS.Where(x => x.UserID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.HaveaHealthProblem;
        }

        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker()
        {
            int id = GetCurrentUserID();
            var worker = _context.HealthMinDBS.Where(x => x.UserID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var healthdto = new InHosbDto { ID = worker.ID, Name = worker.Name, InHosbital = worker.InHosbital };
            return worker.InHosbital;
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

using Microsoft.AspNetCore.Mvc;
using HealthMinAPI.Models;
using HealthMinAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System;

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
        public ActionResult<bool> GetHaveProb()
        {
            var id = GetCurrentUserID();
            var worker = _context.HealthMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.HaveaHealthProblem;
        }

        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker()
        {
            var id = GetCurrentUserID();
            var worker = _context.HealthMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var healthdto = new InHosbDto { ID = worker.ID, Name = worker.Name, InHosbital = worker.InHosbital };
            return worker.InHosbital;
        }
        [HttpGet]
        [Route("CheckHealth/")]
        public IActionResult Ping()
        {
            return Ok();
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

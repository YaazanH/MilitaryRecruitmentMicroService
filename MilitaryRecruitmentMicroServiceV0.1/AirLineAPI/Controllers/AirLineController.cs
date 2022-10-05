using Microsoft.AspNetCore.Mvc;
using AirLineAPI.Models;
using AirLineAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System;

namespace AirLineAPI.Controllers
{
    [ApiController]
    [Route("AirLine")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirLineController : Controller
    {
        

        private readonly AirLineContext _context;

        public AirLineController(AirLineContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAWorker/")]
        
        public ActionResult<bool> GetIsAWorker()
        {
            var id = GetCurrentUserID();
            var worker = _context.AirLineDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.GetIsAWorker;
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

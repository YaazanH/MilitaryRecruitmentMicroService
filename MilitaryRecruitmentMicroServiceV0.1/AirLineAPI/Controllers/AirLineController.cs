using Microsoft.AspNetCore.Mvc;
using AirLineAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;


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
            int id = GetCurrentUserID();
            var worker = _context.AirLineDBS.Where(x => x.UserID == id).FirstOrDefault();
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

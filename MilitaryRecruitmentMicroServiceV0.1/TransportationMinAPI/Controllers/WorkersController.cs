using Microsoft.AspNetCore.Mvc;
using TransportationMinAPI.Models;
using TransportationMinAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;
namespace TransportationMinAPI.Controllers
{
    [ApiController]
    [Route("TransportationMin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WorkersController : Controller
    {
        private readonly TransportationMinContext _context;

        public WorkersController(TransportationMinContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker()
        {
            int id = GetCurrentUserID();
            var worker = _context.TransportationMinDB.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var healthdto = new InHosbDto { ID = worker.ID, Name = worker.Name, InHosbital = worker.InHosbital };
            return worker.IsAWorker;
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

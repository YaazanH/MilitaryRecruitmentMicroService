using Microsoft.AspNetCore.Mvc;
using HealthMinAPI.Models;
using HealthMinAPI.Data;
using System.Linq;

namespace HealthMinAPI.Controllers
{
    [ApiController]
    [Route("HealthMin")]
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
            var worker = _context.HealthMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.HaveaHealthProblem;
        }

        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker(int id)
        {
            var worker = _context.HealthMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var healthdto = new InHosbDto { ID = worker.ID, Name = worker.Name, InHosbital = worker.InHosbital };
            return worker.InHosbital;
        }

    }
}

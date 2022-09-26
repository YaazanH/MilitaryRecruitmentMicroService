using Microsoft.AspNetCore.Mvc;
using AirLineAPI.Models;
using AirLineAPI.Data;
using System.Linq;

namespace AirLineAPI.Controllers
{
    [ApiController]
    [Route("AirLine")]
    public class AirLineController : Controller
    {
        

        private readonly AirLineContext _context;

        public AirLineController(AirLineContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker(int id)
        {
            var worker = _context.AirLineDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.GetIsAWorker;
        }

    }
}

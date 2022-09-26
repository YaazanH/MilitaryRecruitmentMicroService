using Microsoft.AspNetCore.Mvc;
using PoliticalPartiesAPI.Models;
using PoliticalPartiesAPI.Data;
using System.Linq;

namespace PoliticalPartiesAPI.Controllers
{
    [ApiController]
    [Route("PoliticalParties")]
    public class PoliticalPartiesController : Controller
    {
        private readonly PoliticalPartiesContext _context;

        public PoliticalPartiesController(PoliticalPartiesContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAWorker/")]
        public ActionResult<bool> GetIsAWorker(int id)
        {
            var worker = _context.PoliticalPartiesDBS.Where(x => x.ID == id).FirstOrDefault();
            if (worker == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return worker.GetIsAWorker;
        }

    }
}

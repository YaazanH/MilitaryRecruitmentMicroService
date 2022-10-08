using Microsoft.AspNetCore.Mvc;
using MilitaryCollegeAPI.Data;
using System.Linq;

namespace MilitaryCollegeAPI.Controllers
{
    [ApiController]
    [Route("MilitiryCollege")]
    public class SoliderController : Controller
    {
        private readonly MilitiryCollegeContext _context;

        public SoliderController(MilitiryCollegeContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetHasFired/")]
        public ActionResult<bool> GetHasFired(int id)
        {
            var solider = _context.MilitiryCollegeDb.Where(x => x.id == id).FirstOrDefault();
            if (solider == null) return NotFound();
            //var wo = new HaveProbDto { ID = worker.ID, Name = worker.Name, HaveaHealthProblem = worker.HaveaHealthProblem };
            return solider.GotFired;
        }

    }
}

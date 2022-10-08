using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityAPI.Data;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("University")]
    public class MasterConfirmationController : Controller
    {
        private readonly UniversityContext _context;

        public MasterConfirmationController(UniversityContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("HasMasterConfirmation/")]
        public ActionResult<bool> GetHasMasterConfirmation(int id)
        {
            var student = _context.UniversityDb.Where(x => x.id == id).FirstOrDefault();
            if (student == null) return NotFound();

            return student.HasMasterConfirmation;
        }
    }
}

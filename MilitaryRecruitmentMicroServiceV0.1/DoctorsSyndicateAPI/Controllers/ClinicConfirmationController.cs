using DoctorsSyndicateAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoctorsSyndicateAPI.Controllers
{

    [ApiController]
    [Route("DoctorsSyndicate")]
    public class ClinicConfirmationController : Controller
    {
        private readonly DoctorsSyndicateContext _context;

        public ClinicConfirmationController(DoctorsSyndicateContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetClinicConfirmation/")]
        public ActionResult<bool> GetClinicConfirmation(int id)
        {
            var doctor = _context.DoctorsSyndicateDb.Where(x => x.id == id).FirstOrDefault();
            if (doctor == null) return NotFound();
       
            return doctor.HasClinicConfirmation;
        }
    }
}

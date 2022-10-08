using CivilPoliceAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CivilPoliceAPI.Controllers
{
    [ApiController]
    [Route("CivilPolice")]
    public class PersonController : Controller
    {
        private readonly CivilPoliceContext _context;

        public PersonController(CivilPoliceContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("HasClinicConfirmation/")]
        public ActionResult<int> GetHasDonated(int id)
        {
            var person = _context.CivilPoliceDb.Where(x => x.id == id).FirstOrDefault();
            if (person == null) return NotFound();

            return person.NumberOfBrothers;
        }
    }
}

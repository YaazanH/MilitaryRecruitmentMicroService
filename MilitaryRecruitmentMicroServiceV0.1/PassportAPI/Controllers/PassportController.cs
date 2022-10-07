using Microsoft.AspNetCore.Mvc;
using PassportAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassportAPI.Controllers
{

    [ApiController]
    [Route("Passport")]
    public class PassportController : Controller
    {
        private readonly PassportContext _context;

        public PassportController(PassportContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsIsTravel/")]
        public ActionResult<bool> GetIsTravel(int id)
        {
            var Person = _context.PassportDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Person == null) return NotFound();

            return Person.Istravel;
        }
    }
}


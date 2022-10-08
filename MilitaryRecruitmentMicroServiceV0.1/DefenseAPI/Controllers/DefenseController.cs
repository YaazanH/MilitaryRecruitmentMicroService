using DefenseAPI.Data;
using DefenseAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DefenseAPI.Dtos;

namespace DefenseAPI.Controllers
{
    [ApiController]
    [Route("Defense")]
    public class DefenseController : Controller
    {
        private readonly DefenseContext _context;

        public DefenseController(DefenseContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetById/")]
        public ActionResult<DefenseDto> GetById(int id)
        {
            var Solder = _context.DefensesDBS.Where(x => x.id == id).FirstOrDefault();
            if (Solder == null) return NotFound();

            return Solder.AsDtos();

            
        }
    }
}

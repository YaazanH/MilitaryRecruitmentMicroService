using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourtAPI.Data;
using CourtAPI.Models;

namespace CourtAPI.Controllers
{
    [ApiController]
    [Route("Court")]
    public class CourtController : Controller
    {
        private readonly CourtContext _context;

        public CourtController(CourtContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetById/")]
        public ActionResult<Court> GetIsPermit(int id)
        {
            var item = _context.CourtDBS.Where(x => x.id == id).FirstOrDefault();
            if (item == null) return NotFound();

            return item;
        }
    }
}

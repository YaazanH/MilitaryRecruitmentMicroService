using AwqafAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwqafAPI.Controllers
{
    [ApiController]
    [Route("Awqaf")]
    public class AwqafController : Controller
    {


        private readonly AwqafContext _context;

        public AwqafController(AwqafContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIspermit/")]
        public ActionResult<bool> GetIsPermit(int id)
        {
            var Clerk = _context.AwqafDBS.Where(x => x.Id == id).FirstOrDefault();
            if (Clerk == null) return NotFound();

            return Clerk.Ispermit;
        }

    }
}


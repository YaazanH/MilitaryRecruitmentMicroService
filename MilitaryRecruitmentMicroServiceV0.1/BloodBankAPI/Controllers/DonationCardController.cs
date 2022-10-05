using BloodBankAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloodBankAPI.Controllers
{
    [ApiController]
    [Route("BloodBank")]
    public class DonationCardController : Controller
    {
      
            private readonly BloodBankContext _context;

            public DonationCardController(BloodBankContext context)
            {
                _context = context;
            }
            [HttpGet]
            [Route("HasDonated/")]
            public ActionResult<bool> GetHasDonated(int id)
            {
                var worker = _context.BloodBankDb.Where(x => x.id == id).FirstOrDefault();
                if (worker == null) return NotFound();

                return worker.Donated;
            }
        }
    }



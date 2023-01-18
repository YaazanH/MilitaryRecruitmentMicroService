using BloodBankAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace BloodBankAPI.Controllers
{
    [ApiController]
    [Route("BloodBank")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DonationCardController : Controller
    {
      
            private readonly BloodBankContext _context;
        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }

        public DonationCardController(BloodBankContext context)
            {
                _context = context;
            }
            [HttpGet]
            [Route("HasDonated/")]
            public ActionResult<bool> GetHasDonated()
            {
            int id = GetCurrentUserID();
            var worker = _context.BloodBankDb.Where(x => x.UserID == id).FirstOrDefault();
                if (worker == null) return NotFound();
                return worker.Donated;
            }
        }
    }



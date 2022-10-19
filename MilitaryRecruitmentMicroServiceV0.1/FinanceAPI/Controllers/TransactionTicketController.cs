using Microsoft.AspNetCore.Mvc;
using FinanceAPI.Models;
using FinanceAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;

namespace Finance.Controllers
{
    [ApiController]
    [Route("Finance")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FinanceController : Controller
    {
        private readonly FinanceContext _context;
        public FinanceController(FinanceContext context)
        {
            _context = context;
        }
        private int GetCurrentUserID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Int32.Parse(identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid)?.Value);
            }
            return 0;
        }
        [HttpGet]
        [Route("GetUserTransactions/")]
        public ActionResult<TransactionTicket> GetTransaction()
        {
            int id = GetCurrentUserID();
            var Transactions = _context.FinanceDb.Where(x => x.UserID == id).FirstOrDefault();
            if (Transactions == null) return NotFound();

            return Transactions;
        }


    }
}

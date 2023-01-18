using RecordAdminstrationAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Collections.Generic;
using RecordAdminstrationAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RecordAdminstrationAPI.Controllers
{
    [ApiController]
    [Route("RecordAdminstration")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecordAdminstrationController : Controller
    {
        private readonly RecordAdminstrationContext _context;
        public RecordAdminstrationController(RecordAdminstrationContext context)
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
        [Route("GetListOfBros/")]
        public ActionResult<List<int>> GetListOfBros()
        {
            List<int> bro = new List<int>();
            List<int> b = new List<int>();
            int id = GetCurrentUserID();
            var cib = _context.BrothersDB.Where(x => x.Personid == id).ToList();
            if (cib == null) return NotFound();


            foreach (Brothers i in cib)
            {
                bro.Add(i.BrotherId);
            }
            List<RecordsAdminstration> brother = new List<RecordsAdminstration>();
            foreach (int i in bro)
            {
                var broth = _context.RecordAdminstrationDb.Where(x => x.UserID == i && x.Gender == "Male").FirstOrDefault();
                if (broth != null)
                {
                    brother.Add(broth);
                }
            }
            List<int> broID = new List<int>();
            foreach (var item in brother)
            {
                broID.Add(item.UserID);
            }
           
            return broID;
        }

        [HttpGet]
        [Route("GetIfHasMaleBrothers/")]
        public ActionResult<bool> GetIfHaseMaleBrothers()
        {
            List<int> bro = new List<int>();
            int id = GetCurrentUserID();
            var cib = _context.BrothersDB.Where(x => x.Personid == id).ToList();
            if (cib == null) return NotFound();
            foreach (Brothers i in cib)
            {
                bro.Add(i.BrotherId);
            }
            List<RecordsAdminstration> brother = new List<RecordsAdminstration>();
            foreach (int i in bro)
            {
                var broth = _context.RecordAdminstrationDb.Where(x => x.UserID == i && x.Gender == "Male").FirstOrDefault();
                if (broth != null)
                {
                    brother.Add(broth);
                }
            }
            if (brother.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return true;
            }
        }


        [HttpGet]
        [Route("GetAge/")]
        public int GetAge()
        {
            int id = GetCurrentUserID();
            var cib = _context.RecordAdminstrationDb.Where(x => x.UserID == id).FirstOrDefault();
            int dt = DateTime.Now.Year - cib.BirthDate.Year;
            return dt;
        }

        [HttpGet]
        [Route("GetDeath/")]
        public ActionResult<bool> GetDeath(int id)
        {
            var cib = _context.RecordAdminstrationDb.Where(x => x.UserID == id).FirstOrDefault();
            return cib.Death;
        }
    }
}



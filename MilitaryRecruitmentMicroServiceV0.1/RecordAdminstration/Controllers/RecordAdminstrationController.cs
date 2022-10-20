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
                brother = _context.MinistryOfForeignAffairsDB.Where(x => x.id == i && x.Gender == "Male").ToList();

            }
            List<int> broID = new List<int>();
            foreach (var item in brother)
            {
                broID.Add(item.id);
            }
            return broID;
        }

        [HttpGet]
        [Route("GetIfHaseMaleBrothers/")]
        public ActionResult<bool> GetIfHaseMaleBrothers()
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
                brother = _context.MinistryOfForeignAffairsDB.Where(x => x.id == i && x.Gender == "Male").ToList();

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
        public ActionResult<int> GetAge()
        {
            int id = GetCurrentUserID();
            var cib = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            return cib.Age;
        }

        [HttpGet]
        [Route("GetDeath/")]
        public ActionResult<bool> GetDeath(int id)
        {
            var cib = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            return cib.Death;
        }
    }
}


/*foreach (Brothers i in brothers)
{
    var bro = _context.MinistryOfForeignAffairsDB.Where(x => x.id == i.BrotherId && x.Gender == "male").ToList();
    return bro;
}*/

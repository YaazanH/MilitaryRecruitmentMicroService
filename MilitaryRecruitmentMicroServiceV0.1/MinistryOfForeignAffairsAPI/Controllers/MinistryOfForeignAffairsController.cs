using Microsoft.AspNetCore.Mvc;
using MinistryOfForeignAffairsAPI.Models;
using MinistryOfForeignAffairsAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;

namespace MinistryOfForeignAffairsAPI.Controllers
{
    [ApiController]
    [Route("MinistryOfForeignAffairs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompetentAuthorityController : Controller
    {
        private readonly MinistryOfForeignAffairsContext _context;
        public CompetentAuthorityController(MinistryOfForeignAffairsContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetServedInOtherCountry/")]
        public ActionResult<bool> GetServedInOtherCountry(int id)
        {
            var Person = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.ServedInAnotherArmy;
        }
        [HttpGet]
        [Route("GetFamilyMemberOutsideTheCountry/")]
        public ActionResult<bool> GetFamilyMemberOutsideTheCountry(int id)
        {
            var Person = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.FamilyMemberOutsideTheCountry;
        }

        [HttpGet]
        [Route("GetRatificationOfBeingAManOfGod/")]
        public ActionResult<bool> GetRatificationOfBeingAManOfGod(int id)
        {
            var Person = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.RatificationOfBeingAManOfGod;
        }

        [HttpGet]
        [Route("GetAmbassadors/")]
        public ActionResult<bool> GetAmbassadors(int id)
        {
            var Person = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.Ambassadors;
        }

        [HttpGet]
        [Route("GetInsideTheCountry/")]
        public ActionResult<bool> GetInsideTheCountry(int id)
        {
            var Person = _context.MinistryOfForeignAffairsDB.Where(x => x.id == id).FirstOrDefault();
            if (Person == null) return NotFound();
            return Person.Inside;
        }
    }
}



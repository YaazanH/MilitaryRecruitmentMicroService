using Microsoft.AspNetCore.Mvc;
using HighEduMinAPI.Models;
using HighEduMinAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System;

namespace HighEduMinAPI.Controllers
{
    [ApiController]
    [Route("HighEduMin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HighEduMinController : Controller
    {
        private readonly HighEduMinContext _context;

        public HighEduMinController(HighEduMinContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAStudent/")]
        public ActionResult<bool> GetIsAStudent()
        {
            var id = GetCurrentUserID();
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
            //var St = new IsAStudentDto { ID = Student.ID, Name = Student.Name, IsAStudent = Student.IsAStudent };
            return Student.IsAStudent;
        }

        [HttpGet]
        [Route("GetChangeCert/")]
        public ActionResult<bool> ChangeCert()
        {
            var id = GetCurrentUserID();
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
           // var St = new ChangeCertDto { ID = Student.ID, Name = Student.Name, ChangeCert = Student.ChangeCert };
            return Student.ChangeCert;
        }

        [HttpGet]
        [Route("GetGovSendToStudy/")]
        public ActionResult<bool> GovSendToStudy()
        {
            var id = GetCurrentUserID();
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
            //var St = new GovSendToStudyDto { ID = Student.ID, Name = Student.Name, GovSendToStudy = Student.GovSendToStudy };
            return Student.GovSendToStudy;
        }

        [HttpGet]
        [Route("GetStudyOutSide/")]
        public ActionResult<bool> StudyOutSide()
        {
            var id = GetCurrentUserID();
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
           //var St = new StudyOutSideDto { ID = Student.ID, Name = Student.Name, StudyOutSide = Student.StudyOutSide };
            return Student.StudyOutSide;
        }

        [HttpGet]
        [Route("CheckHealth/")]
        public IActionResult Ping()
        {
            return Ok();
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
    }
}

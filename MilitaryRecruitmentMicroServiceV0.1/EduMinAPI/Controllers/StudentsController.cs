using EduMinAPI.Models;
using EduMinAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace EduMinAPI.Controllers
{
    [ApiController]
    [Route("EduMinAPI")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsController : Controller
    {
        private readonly EduMinContext _context;
        public StudentsController(EduMinContext context)
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
        [Route("GetIsAStudent/")]
        public ActionResult<bool> GetIsAStudent()
        {
            int id = GetCurrentUserID();
            var Student = _context.EduMinDB.Where(x => x.UserID == id).FirstOrDefault();
            if (Student == null) return NotFound();

            return Student.IsAStudent;
        }
        [HttpGet]
        [Route("GetIsDroppedOut/")]
        public ActionResult<bool> GetIsDroppedOut()
        {
            int id = GetCurrentUserID();
            var Student = _context.EduMinDB.Where(x => x.UserID == id).FirstOrDefault();
            if (Student == null) return NotFound();

            return Student.IsDroppedOut;
        }

    }
}

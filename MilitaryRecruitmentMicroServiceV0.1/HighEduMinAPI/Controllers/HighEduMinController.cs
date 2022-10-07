using Microsoft.AspNetCore.Mvc;
using HighEduMinAPI.Models;
using HighEduMinAPI.Data;
using System.Linq;
namespace HighEduMinAPI.Controllers
{
    [ApiController]
    [Route("HighEduMin")]
    public class HighEduMinController : Controller
    {
        private readonly HighEduMinContext _context;

        public HighEduMinController(HighEduMinContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetIsAStudent/")]
        public ActionResult<bool> GetIsAStudent(int id)
        {
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
            //var St = new IsAStudentDto { ID = Student.ID, Name = Student.Name, IsAStudent = Student.IsAStudent };
            return Student.IsAStudent;
        }

        [HttpGet]
        [Route("GetChangeCert/")]
        public ActionResult<bool> ChangeCert(int id)
        {
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
           // var St = new ChangeCertDto { ID = Student.ID, Name = Student.Name, ChangeCert = Student.ChangeCert };
            return Student.ChangeCert;
        }

        [HttpGet]
        [Route("GetGovSendToStudy/")]
        public ActionResult<bool> GovSendToStudy(int id)
        {
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
            //var St = new GovSendToStudyDto { ID = Student.ID, Name = Student.Name, GovSendToStudy = Student.GovSendToStudy };
            return Student.GovSendToStudy;
        }

        [HttpGet]
        [Route("GetStudyOutSide/")]
        public ActionResult<bool> StudyOutSide(int id)
        {
            var Student = _context.HighEduMinDBS.Where(x => x.ID == id).FirstOrDefault();
            if (Student == null) return NotFound();
           //var St = new StudyOutSideDto { ID = Student.ID, Name = Student.Name, StudyOutSide = Student.StudyOutSide };
            return Student.StudyOutSide;
        }
    }
}

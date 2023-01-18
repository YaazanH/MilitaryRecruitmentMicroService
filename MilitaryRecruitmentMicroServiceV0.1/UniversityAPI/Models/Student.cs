using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public int UserID { get; set; }
        public String Name { get; set; }

        public Boolean HasMasterConfirmation { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int YearsOfStudy { get; set; }

        public Boolean IsStudyingNow{ get; set; }
    }
}

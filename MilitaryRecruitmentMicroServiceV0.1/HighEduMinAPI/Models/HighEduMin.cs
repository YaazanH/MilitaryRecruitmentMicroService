using System.ComponentModel.DataAnnotations;

namespace HighEduMinAPI.Models
{
    public class HighEduMin
    {

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsAStudent { get; set; }

        public bool StudyOutSide { get; set; }

        public bool GovSendToStudy { get; set; }

        public bool ChangeCert { get; set; }
    }
}

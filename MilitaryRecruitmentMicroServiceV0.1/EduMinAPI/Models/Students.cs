using System;
using System.ComponentModel.DataAnnotations;
namespace EduMinAPI.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }

        public string FullName { get; set; }
        public bool IsAStudent { get; set; }
        public bool IsDroppedOut { get; set; }

    }
}

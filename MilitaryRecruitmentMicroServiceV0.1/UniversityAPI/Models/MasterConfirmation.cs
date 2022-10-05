using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models
{
    public class MasterConfirmation
    {
        [Key]
        public int id { get; set; }

        public String Name { get; set; }

        public Boolean HasMasterConfirmation { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorsSyndicateAPI.Models
{
    public class ClinicConfirmation
    {
        [Key]
        public int id { get; set; }

        public String Name { get; set; }

        public Boolean HasClinicConfirmation { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}

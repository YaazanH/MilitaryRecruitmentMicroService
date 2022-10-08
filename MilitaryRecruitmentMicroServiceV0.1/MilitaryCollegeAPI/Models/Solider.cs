using System;
using System.ComponentModel.DataAnnotations;

namespace MilitaryCollegeAPI.Models
{
    public class Solider
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public bool GotFired { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}

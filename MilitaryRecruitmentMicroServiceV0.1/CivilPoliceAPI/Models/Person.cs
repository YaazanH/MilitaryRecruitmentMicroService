using System;
using System.ComponentModel.DataAnnotations;

namespace CivilPoliceAPI.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        public int UserID { get; set; }

        public String Name { get; set; }

        public int NumberOfBrothers { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}

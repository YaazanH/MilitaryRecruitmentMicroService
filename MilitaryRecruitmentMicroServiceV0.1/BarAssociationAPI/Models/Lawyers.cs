using System;
using System.ComponentModel.DataAnnotations;

namespace BarAssociationAPI.Models
{
    public class Lawyers
    {
        [Key]
        public int id { get; set; }
        public string fullname { get; set; }
        public DateTime graduationDate { get; set; }
        public DateTime joinDate { get; set; }
        public DateTime trainstartDate { get; set; }
    }
}

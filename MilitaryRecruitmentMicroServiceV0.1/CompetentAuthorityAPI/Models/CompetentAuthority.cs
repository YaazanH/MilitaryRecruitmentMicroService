using System;
using System.ComponentModel.DataAnnotations;

namespace CompetentAuthorityAPI.Models
{
    public class CompetentAuthority
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTimeOffset EntryDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtAPI.Models
{
    public class Court
    {
        [Key]
        public int id { set; get; }
        public string FullName { set; get; }
        public string verdict { set; get; }
        public string time { set; get; }
        public DateTimeOffset VerdictDate { set; get; }
    }
}

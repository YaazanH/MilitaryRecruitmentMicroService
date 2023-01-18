using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DefenseAPI.Models
{
    public class Defense
    {
        [Key]
        public int id { set; get; }

        public int UserID { get; set; }
        public string FullName { set; get; }
        public bool Isin { set; get; }
        public string Unit { set; get; }

    }
}

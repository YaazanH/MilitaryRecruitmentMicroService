using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PassportAPI.Models
{
    public class Passport
    {
        [Key]
        public int ID { set; get; }
        public string FullName { set; get; }
        public bool Istravel { set; get; }

    }
}

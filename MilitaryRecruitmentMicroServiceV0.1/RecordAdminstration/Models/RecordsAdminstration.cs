using RecordAdminstrationAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RecordAdminstrationAPI.Models
{
    public class RecordsAdminstration
    {
        [Key]
        public int id { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }

        public String Gender { get; set; }

        public  ICollection<Brothers> Brothers { get; set; }

        public String FathersName { get; set; }

        public String MothersName { get; set; }
        public Boolean Death { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}

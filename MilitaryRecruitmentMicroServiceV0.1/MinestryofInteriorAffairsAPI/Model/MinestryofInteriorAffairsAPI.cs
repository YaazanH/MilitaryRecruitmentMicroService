using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinestryofInteriorAffairs.Model
{
    public class MinestryofInteriorAffairsAPI
    {
        [Key]
        public int Id { set; get; }
        public string FullName { set; get; }
        
        public int NumofYear { set; get; }



    }
}

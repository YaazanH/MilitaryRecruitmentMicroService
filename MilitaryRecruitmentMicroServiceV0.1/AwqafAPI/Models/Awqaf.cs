using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AwqafAPI.Models
{
    public class Awqaf
    {
        [Key]
        public int Id { set; get; }
        public string FullName { set; get; }
        public bool Ispermit { set; get; }
    }
}

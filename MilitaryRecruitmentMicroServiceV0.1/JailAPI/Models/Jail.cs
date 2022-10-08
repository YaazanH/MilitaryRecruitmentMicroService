using System;
using System.ComponentModel.DataAnnotations;

namespace JailAPI.Models
{
    public class Jail
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTimeOffset EntryDate { get; set; }
        public DateTimeOffset ReleasDate { get; set; }
    }
}

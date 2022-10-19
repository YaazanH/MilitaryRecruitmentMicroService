using System;
using System.ComponentModel.DataAnnotations;

namespace TransportationMinAPI.Models
{
    public class Workers
    {
        [Key]
        public int ID { get; set; }

        public string FullName { get; set; }

        public bool IsAWorker { get; set; }
        public DateTime dateofjoin { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace AirLineAPI.Models
{
    public class AirLine
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public bool GetIsAWorker { get; set; }
    }
}

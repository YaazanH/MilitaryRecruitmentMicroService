using System.ComponentModel.DataAnnotations;

namespace HealthMinAPI.Models
{
    public class HealthMin
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public bool InHosbital { get; set; }

        public bool HaveaHealthProblem { get; set; }
    }
}

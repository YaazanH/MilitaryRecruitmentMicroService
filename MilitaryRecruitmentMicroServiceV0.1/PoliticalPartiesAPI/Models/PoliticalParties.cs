using System.ComponentModel.DataAnnotations;

namespace PoliticalPartiesAPI.Models
{
    public class PoliticalParties
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public bool GetIsAWorker { get; set; }
    }
}

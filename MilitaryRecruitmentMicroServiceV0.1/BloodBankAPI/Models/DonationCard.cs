using System;
using System.ComponentModel.DataAnnotations;

namespace BloodBankAPI.Models
{
    public class DonationCard
    {
        [Key]
        public int id { get; set; }

        public int UserID { get; set; }

        public String Name { get; set; }

        public Boolean Donated { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}

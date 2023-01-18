using System;
using System.ComponentModel.DataAnnotations;

namespace MinistryOfForeignAffairsAPI.Models
{
    public class MinistryOfForeignAffairs
    {
        [Key]
        public int id { get; set; }
        public int UserID { get; set; }
        public string name { get; set; }
        public bool FamilyMemberOutsideTheCountry { get; set; }
        public bool ServedInAnotherArmy { get; set; }
        public bool Inside { get; set; }
        public bool RatificationOfBeingAManOfGod { get; set; }
        public bool Ambassadors { get; set; }
    }
}

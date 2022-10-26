using System.ComponentModel.DataAnnotations;

namespace PassportAPI.Model
{
    public class Passport
    {
        [Key]
        public int ID { set; get; }
        public string FullName { set; get; }
        public bool Istravel { set; get; }
        public int NumberOfDaysInSideCoun { get; set; }

        public int NumberOfDaysOutsideCoun { get; set; }
    }
}

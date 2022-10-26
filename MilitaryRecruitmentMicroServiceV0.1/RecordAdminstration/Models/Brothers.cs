
using Microsoft.EntityFrameworkCore;

namespace RecordAdminstrationAPI.Models
{
    
    public class Brothers
    {
        public int id { get; set; }
        public int Personid { get; set; }
        public int BrotherId { get; set; }
    }
}

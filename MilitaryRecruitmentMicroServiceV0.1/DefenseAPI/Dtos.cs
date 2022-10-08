using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DefenseAPI.Models;

namespace DefenseAPI
{
    public class Dtos
    {
        public record DefenseDto(int id,string fullname, bool Isin,string unit);
        
        
       
    }
}

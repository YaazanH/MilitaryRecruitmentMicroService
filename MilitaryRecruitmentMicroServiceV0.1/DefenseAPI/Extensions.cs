using DefenseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static DefenseAPI.Dtos;

namespace DefenseAPI.Extensions
{
    public static class Extensions
    {
        public static DefenseDto AsDtos(this Defense defense)
        {

            return new DefenseDto(defense.id, defense.FullName, defense.Isin, defense.Unit);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.Domain.Interfaces
{
    public interface IRangeTime
    {
        public bool IsWithinRange(DateTime dateTime);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.Repository
{
    public interface IRangeTime
    {
        public bool IsWithinRange(DateTime dateTime);
    }
}
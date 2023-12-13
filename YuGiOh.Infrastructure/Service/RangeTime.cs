
using YuGiOh.Domain.Interfaces;

namespace YuGiOh.Infrastructure.Service
{
    public class RangeTime : IRangeTime
    {
       

        public RangeTime(DateTime startTime, DateTime endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
        }

        public DateTime _startTime {get;}

        public DateTime _endTime { get; }

        public bool IsWithinRange(DateTime dateTime)
        {
            return dateTime >= _startTime && dateTime <= _endTime;
        }
    }
}


using YuGiOh.Domain.Interfaces;

namespace YuGiOh.Infrastructure.Service
{
    public class RangeTime : IRangeTime
    {
        private readonly DateTime _startTime;
        private readonly DateTime _endTime;

        public RangeTime(DateTime startTime, DateTime endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
        }

        public bool IsWithinRange(DateTime dateTime)
        {
            return dateTime >= _startTime && dateTime <= _endTime;
        }
    }
}

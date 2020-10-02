using System;

namespace Orikivo
{
    public struct Uptime
    {
        public Uptime(DateTime time)
        {
            Boot = time;
        }
        public static Uptime FromBootTime(DateTime time)
        {
            return new Uptime(time);
        }
        // the time of launch
        private DateTime Boot { get; set; }

        // this class when referenced by itself should return a TimeSpan
        // displaying the duration of time it was up.
    }
}
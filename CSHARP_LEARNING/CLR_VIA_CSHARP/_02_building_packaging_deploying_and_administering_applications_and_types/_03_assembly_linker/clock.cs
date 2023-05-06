using System;

namespace ClockerLol
{
    public static class Clock
    {
        public static string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }
}

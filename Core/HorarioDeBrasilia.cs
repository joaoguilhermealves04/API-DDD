using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class HorarioDeBrasilia
    {
        public static DateTime Get()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ZonaDeTempo.ObterZonaDeTempo());
        }
        public static DateTime Set(DateTime date)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(date.ToUniversalTime(), ZonaDeTempo.ObterZonaDeTempo());
        }
    }

    public static class ZonaDeTempo
    {
        public static TimeZoneInfo ObterZonaDeTempo()
        {
            TimeZoneInfo cetZone;

            try
            {
                cetZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            catch
            {
                cetZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }

            return cetZone;
        }
    }

}

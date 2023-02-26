using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace _19T1021067.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        public static DateTime? DMYStringtoDataTime(string s,string format="d/M/yyyy")
        {
            try
            {
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }
    }
}
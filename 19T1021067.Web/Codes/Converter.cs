using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using _19T1021067.DomainModels;

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
        public static UserAccount CookiesToUserAccount(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserAccount>(value);
        }
    }
}
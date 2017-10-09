using System;
using System.Text; 
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790A4.Extensions
{
    public static class EmailExtensions
    {
        public static string ToBase64(this string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static string FromBase64(this string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }
    }

}
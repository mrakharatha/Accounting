using System;
using System.Collections.Generic;
using System.Globalization;

namespace Accounting.Domain.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
        public static string ToShamsiTime(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00") + " " + value.ToString("HH:mm:ss");
        }  
      
        public static DateTime ToDateTime(this string dateTime)
        {
            PersianCalendar p = new PersianCalendar();
            string[] parts = dateTime.Split('/', '-');
            return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0, 0, 0);
        }
    }

}

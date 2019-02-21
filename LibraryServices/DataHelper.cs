using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryServices
{
    public class DataHelper
    {
        public static IEnumerable<String> HumanizeBizHours(IEnumerable<BranchHours> branchHours)
        {
            var hour = new List<String>();
            foreach (var times in branchHours)
            {
                var day = HumanizeDay(times.DayOfWeek);
                var openHour = HumanizeTime(times.OpenTime);
                var closeTime = HumanizeTime(times.CloseTime);
                var timeEntry = $"{day} {openHour} to {closeTime}";
                hour.Add(timeEntry);
            }
            return hour;
        }

        public static String HumanizeDay(int dayNumber)
        {
            return Enum.GetName(typeof(DayOfWeek), dayNumber-1);
        }

        public static String HumanizeTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }
    }
}

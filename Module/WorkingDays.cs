using FinalTestAssignment.Module.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Controllers
{
    public class WorkingDays : IWorkingDays
    {
        public int GetWorkingDays(DateTime from, DateTime to)
        {
            var totalDays = 0;
            var holidays = GetPublicHolidays(from, to);
            for (var date = from.AddDays(1); date < to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Distinct().Contains(date))
                    totalDays++;
            }
            return totalDays;
        }

        private List<DateTime> GetPublicHolidays(DateTime from, DateTime to)
        {
            var holidayDates = new List<DateTime>();


            //********* Holidays in which Holiday will be shifted to Monday in case of Weekend like New Year*******//

            // For "New Year Day"
            AddSameDayIfNotWeekendHoliday(from, to, 1, 1, holidayDates);

            // For "Australia Day"
            AddSameDayIfNotWeekendHoliday(from, to, 1, 27, holidayDates);

            //********************************************************************************//


            //**************Holidays on Certain Days of Month like Queens Holiday********//

            // For "Queen Birthday"
            AddCertainDayInaMonthHoliday(from, to, holidayDates);

            //****************************************************//


            //********* Fixed Date Holiday like Anzac Day*******//

            // For "Canberra Day"
            AddFixedDateHoliday(from, to, 3, 9, holidayDates);

            // For "Good Friday"
            AddFixedDateHoliday(from, to, 4, 10, holidayDates);

            // For "Easter Saturday"
            AddFixedDateHoliday(from, to, 4, 11, holidayDates);

            // For "Easter Sunday"
            AddFixedDateHoliday(from, to, 4, 12, holidayDates);

            // For "Easter Monday"
            AddFixedDateHoliday(from, to, 4, 13, holidayDates);

            // For "Anzac Day"
            AddFixedDateHoliday(from, to, 4, 25, holidayDates);

            // For "Reconciliation Day"
            AddFixedDateHoliday(from, to, 6, 1, holidayDates);

            // For "Labour Day"
            AddFixedDateHoliday(from, to, 10, 5, holidayDates);

            // For "Christmas Day"
            AddFixedDateHoliday(from, to, 12, 25, holidayDates);

            // For "Boxing Day"
            AddFixedDateHoliday(from, to, 12, 28, holidayDates);

            //***********************************//

            return holidayDates;
        }

        private void AddSameDayIfNotWeekendHoliday(DateTime from, DateTime to, int month, int day, List<DateTime> holidayDates)
        {
            var holidayDate = new DateTime(from.Year, month, day);

            if (from < holidayDate && holidayDate < to)
            {
                if (holidayDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    holidayDate = holidayDate.AddDays(2);
                }
                else if (holidayDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidayDate = holidayDate.AddDays(1);
                }
                holidayDates.Add(holidayDate);
            }
        }

        private void AddCertainDayInaMonthHoliday(DateTime from, DateTime to, List<DateTime> holidayDates)
        {
            // Find Date By Using From Year
            var secondMondayOfJune = new DateTime(from.Year, 6, 1);

            if (from < secondMondayOfJune && secondMondayOfJune < to)
            {
                // find first Monday
                while (secondMondayOfJune.DayOfWeek != DayOfWeek.Monday)
                    secondMondayOfJune = secondMondayOfJune.AddDays(1);

                // add one weeks
                secondMondayOfJune = secondMondayOfJune.AddDays(7);
                holidayDates.Add(secondMondayOfJune);
            }
        }


        private void AddFixedDateHoliday(DateTime from, DateTime to, int month, int day, List<DateTime> holidayDates)
        {
            var holidayDate = new DateTime(from.Year, month, day);
            if (from < holidayDate && holidayDate < to)
            {
                holidayDates.Add(holidayDate);
            }
        }
    }

}
using System.Globalization;

namespace Shared.Util.Extensions;

public static class DateTimeExtensions
{
    public static DateOnly ToDateOnly(this DateTime date)
    {
        return DateOnly.FromDateTime(date);
    }

    public static TimeOnly ToTimeOnly(this DateTime date)
    {
        return TimeOnly.FromDateTime(date);
    }

    public static int WeekNumber(this DateTime date)
    {
        return new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static bool IsBetween(this DateTime date, DateTime left, DateTime right)
    {
        return date >= left && date <= right;
    }

    public static DateTime ValidateMinDate(this DateTime date, Exception exception)
    {
        if(date.Date < DateTime.Now.Date) throw exception;

        return date;
    }

    public static DateTime ToDateTime(this DateOnly date)
    {
        return date.ToDateTime(TimeOnly.MinValue);
    }
}

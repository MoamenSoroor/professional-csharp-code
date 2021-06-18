using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace ProCSharpCode.CSharpBasics
{
    
    // ------------------------ DateTimeTraining -------------------------

    public class DateTimeTraining
    {
        // Test Method
        public static void TestDateTime()
        {
            DateTimeMethodsAndProperties();


        }

        public static void DateTimeMethodsAndProperties()
        {
            // Static properties of datatime
            DateTime currentDateTime = DateTime.Now;  //returns current date and time
            DateTime todaysDate = DateTime.Today; // returns today's date
            DateTime currentDateTimeUTC = DateTime.UtcNow;// returns current UTC date and time

            DateTime maxDateTimeValue = DateTime.MaxValue; // returns max value of DateTime
            DateTime minDateTimeValue = DateTime.MinValue; // returns min value of DateTime

            Console.WriteLine(currentDateTime);
            Console.WriteLine(todaysDate);
            Console.WriteLine(currentDateTimeUTC);
            Console.WriteLine(maxDateTimeValue);
            Console.WriteLine(minDateTimeValue);


            // 
            var dateTime = new DateTime(); 
            Console.WriteLine(dateTime); // will be [01/01/0001 12:00:00 ص]

            // public DateTime(long ticks);
            // Ticks
            // Ticks is a date and time expressed in the number of 100 - nanosecond intervals 
            // that have elapsed since January 1, 0001, at 00:00:00.000 in the Gregorian calendar.
            // 
            // TicksPerMillisecond = 10000;
            // TicksPerSecond = 10000000;
            // TicksPerMinute = 600000000;
            // TicksPerHour = 36000000000;
            // TicksPerDay = 864000000000;

            dateTime = new DateTime(10001000000100101);
            Console.WriteLine(dateTime);  // 01/01/0001 12:00:09 ص

            // DateTimeKind:  Unspecified = 0, Utc = 1, Local = 2
            dateTime = new DateTime(10001000000100101, DateTimeKind.Local);
            Console.WriteLine(dateTime);  // 01/01/0001 12:00:09 ص

            // public DateTime(int year, int month, int day);
            //  The year can be from 0001 to 9999, and the Month 
            //  can be from 1 to 12, and the day can be from 1 to 31
            dateTime = new DateTime(1995,1,22);
            Console.WriteLine(dateTime);

            // public DateTime(int year, int month, int day, int hour, int minute, int second);
            dateTime = new DateTime(1995, 1, 22,13,30,40);
            Console.WriteLine(dateTime);

            // basic datetime properties
            Console.WriteLine(dateTime.Day);
            Console.WriteLine(dateTime.DayOfWeek);
            Console.WriteLine(dateTime.DayOfYear);
            Console.WriteLine(dateTime.Month);
            Console.WriteLine(dateTime.Year);
            Console.WriteLine(dateTime.Hour);
            Console.WriteLine(dateTime.Minute);
            Console.WriteLine(dateTime.Millisecond);

            // get only date without time
            DateTime dateOfDateTime = dateTime.Date;
            Console.WriteLine(dateOfDateTime);

            // get time only without date
            TimeSpan timeOfDateTime = dateTime.TimeOfDay;
            Console.WriteLine(timeOfDateTime);

            dateTime = new DateTime(1995, 1, 22, 12, 30, 00);
            Console.WriteLine(dateTime);
            DateTime datetime2 = dateTime.AddSeconds(200);
            datetime2 = dateTime.AddMinutes(200);
            datetime2 = dateTime.AddHours(200);
            datetime2 = dateTime.AddDays(200);
            datetime2 = dateTime.AddMonths(200);
            datetime2 = dateTime.AddYears(200);




            // TimeSpan
            // ------------------------------------------------------------------
            // - TimeSpan is a struct that is used to represent time in days, hour, 
            //   minutes, seconds, and milliseconds.
            // - it also represent an interval of time
            // - it is immutable


            // Some Important Constants

            // public const long TicksPerMillisecond = 10000;
            // public const long TicksPerSecond = 10000000;
            // public const long TicksPerMinute = 600000000;
            // public const long TicksPerHour = 36000000000;
            // public const long TicksPerDay = 864000000000;
            Console.WriteLine($"TimeSpan.TicksPerMillisecond = {TimeSpan.TicksPerMillisecond}");
            Console.WriteLine($"TimeSpan.TicksPerSecond = {TimeSpan.TicksPerSecond}");
            Console.WriteLine($"TimeSpan.TicksPerMinute = {TimeSpan.TicksPerMinute}");
            Console.WriteLine($"TimeSpan.TicksPerHour = {TimeSpan.TicksPerHour}");
            Console.WriteLine($"TimeSpan.TicksPerDay = {TimeSpan.TicksPerDay}");
            
            //creating TimeSpan
            TimeSpan span = new TimeSpan(12,3,30,40);
            span = TimeSpan.Zero;
            span = TimeSpan.FromSeconds(23423413);
            span = TimeSpan.FromMinutes(10123012);
            span = TimeSpan.FromHours(10123012);
            span = TimeSpan.FromDays(10123012);
            span = TimeSpan.FromMilliseconds(1012301213123);
            span = TimeSpan.FromTicks(130313992339239);

            

            // get days or minutes or hours or seconds in that interval
            Console.WriteLine(span.Days);
            Console.WriteLine(span.Hours);
            Console.WriteLine(span.Minutes);
            Console.WriteLine(span.Seconds);
            Console.WriteLine(span.Milliseconds);

            // get total interval in days or minutes or hours or seconds or milliseconds
            Console.WriteLine(span.TotalDays);
            Console.WriteLine(span.TotalHours);
            Console.WriteLine(span.TotalMinutes);
            Console.WriteLine(span.TotalSeconds);
            Console.WriteLine(span.TotalMilliseconds);


            // TimeSpan String Formats passed to span in en-us format
            // -----------------------------------------------------------
            // format: 
            // [ws][-]{ d | [d.]hh:mm[:ss[.ff]] }[ws]
            // 
            // Element  Description
            // ----------------------
            // ws       Optional white space.
            // -        An optional minus sign, which indicates a negative TimeSpan.
            // d        Days, ranging from 0 to 10675199.
            // .        A culture - sensitive symbol that separates days from hours.The invariant format uses a period(".") character.
            // hh       Hours, ranging from 0 to 23.
            // :	    The culture-sensitive time separator symbol.The invariant format uses a colon(":") character.
            // mm       Minutes, ranging from 0 to 59.
            // ss       Optional seconds, ranging from 0 to 59.
            // .A       culture - sensitive symbol that separates seconds from fractions of a second.The invariant format uses a period(".") character.
            // ff       Optional fractional seconds, consisting of one to seven decimal digits.
            // 
            // -------------------------------------------------
            //Examples:
            // days:                                        d               40
            // hours and minutes:                           hh:mm           02:23
            // days, hours and minutes:                     d.hh:mm         113.02:23
            // days, hours, minutes and seconds:            d.hh:mm:ss      123.02:23:45
            // days, hours, minutes, seconds, and fraction: d.hh:mm:ss      123.02:23:45.23132
            
            // in minus: 
            //      -40
            //      -02:23
            //      -30.02:23
            //      -30.02:23:45
            //      -30.02:23:45


            // - note that hours and minutes and seconds must be in two digits
            //    like 02 not 2 
            // - note also that if format is wronge : FormatException will be thrown
            // - if you exceed the range of an interval ,OverflowException will be thrown

            try
            {
                span = TimeSpan.Parse("6");
                Console.WriteLine(span);
                span = TimeSpan.Parse("6:12");
                Console.WriteLine(span);
                span = TimeSpan.Parse("6:12:14");
                Console.WriteLine(span);
                span = TimeSpan.Parse("6:12:14:45");
                Console.WriteLine(span);
                span = TimeSpan.Parse("6.2:114:45");
                Console.WriteLine(span);
                span = TimeSpan.Parse("6:12:14:45.3448");
                Console.WriteLine(span);

                // you can also use TryParse();
                // look also at ParseExact() and TryParseExact()
            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) { Console.WriteLine("Unknow Error in Parsing TimeSpan."); }




            // add and subtract time with timespans
            span = TimeSpan.FromDays(6); // 6 days
            Console.WriteLine(span);


            span = span.Add(new TimeSpan(10,15,30,23));
            Console.WriteLine(span);


            span = span.Add(TimeSpan.FromSeconds(200));
            Console.WriteLine(span);


            span = span.Add(TimeSpan.FromHours(200));
            Console.WriteLine(span);

            span = span.Add(TimeSpan.FromDays(200));
            Console.WriteLine(span);


            span = span.Add(TimeSpan.FromTicks(232393394423));
            Console.WriteLine(span);

            // subtract
            span = span.Subtract(TimeSpan.FromSeconds(200));
            span = span.Subtract(TimeSpan.FromTicks(232393394423));
            Console.WriteLine(span);

            // negate
            span = TimeSpan.FromDays(200);
            span = span.Negate(); // now - 200 days
            Console.WriteLine(span);

            // subtract of negated span will reduce a different result
            span = span.Subtract(TimeSpan.FromDays(6)); // will produce -206 days
            Console.WriteLine(span);

            // get absolute value of timespan, if it is negative it will be positive
            // subtract of negated span will reduce a different result
            span = span.Duration();
            Console.WriteLine(span);

        }



    }

    // --------------------------------------------------------------

}
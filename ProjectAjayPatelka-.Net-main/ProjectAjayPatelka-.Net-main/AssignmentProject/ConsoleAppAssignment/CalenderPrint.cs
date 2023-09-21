using System;
using System.Globalization;

namespace Calendar
{
    class Program
    {
        static int promptDay = new int();
        static int year = new int();
        static int month = new int();
        static int[,] calendar = new int[6, 7];
        static int totalDays=31;
        static void Main(string[] args)
        {
            Console.Write("Enter the year? ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the month (January = 1, etc): ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the day you want to see the dates for (Mon = 0, etc): ");
            promptDay = Convert.ToInt32(Console.ReadLine());
            DrawHeader();
            FillCalendar();
            // DrawCalendar();
            DrawCalendars();
            Console.ReadLine();
        }

        static void DrawHeader()
        {
            Console.Write("\n\n");
            //gives you the month and year at the top of the calendar
            Console.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + " " + year);
            Console.WriteLine("Mo Tu We Th Fr Sa Su");
        }

        static void FillCalendar()
        {
            int currentDay = 1;
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                int day = i;
                for (int j = 0; j < calendar.GetLength(1) && currentDay <= totalDays ; j++)
                {
                    if (i == 0 && day > j)
                    {
                        calendar[i, j] = 0;
                    }
                    else
                    {
                        if (j != promptDay)
                        {
                            calendar[i, j] = 0;
                        }
                        else
                        {
                            calendar[i, j] = currentDay;
                        }
                        currentDay++;
                    }
                }
            }
        }

        static void DrawCalendar()
        {
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1); j++)
                {
                    if (calendar[i, j] > 0)
                    {
                        if (calendar[i, j] < 10)
                        {
                            Console.Write(" " + calendar[i, j] + " ");
                        }
                        else
                        {
                            Console.Write(calendar[i, j] + " ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }
        static void DrawCalendars()
        {
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1); j++)
                {
                    Console.Write(calendar[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
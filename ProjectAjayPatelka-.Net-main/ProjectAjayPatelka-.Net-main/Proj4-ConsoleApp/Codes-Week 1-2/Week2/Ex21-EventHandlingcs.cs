using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Proj1_SampleConApp.Week_2
{
    //We will use Action Delegate for creating events in our app as an example.
    class AlarmClock
    {

        private DateTime _alarmTime;
        public event Action<String> RaiseAlarm;
        public AlarmClock(DateTime alarm)
        {
            _alarmTime = alarm;
        }
        public void display()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                if (DateTime.Now.Minute == _alarmTime.Minute)
                    if (RaiseAlarm != null)
                        Console.WriteLine("Time to wake up.");
                System.Threading.Thread.Sleep(1000);
            } while (true);
        }
    }
    class Ex21EventHandling
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock(DateTime.Now.AddSeconds(30));
            clock.RaiseAlarm += Clock_RaiseAlarm;
            clock.display();
        }
        private static void Clock_RaiseAlarm(string value)
        {
            Console.WriteLine(value);
        }
    }
}
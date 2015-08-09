using System;
using System.Linq;
using DomainLogic;

namespace CourseScheduleConsole
{
    public class Program
    {
        private static readonly string[] TestListOfCourses = {
            "Introduction to Paper Airplanes: ",
            "Advanced Throwing Techniques: Introduction to Paper Airplanes",
            "History of Cubicle Siege Engines: Rubber Band Catapults 101",
            "Advanced Office Warfare: History of Cubicle Siege Engines",
            "Rubber Band Catapults 101: ",
            "Paper Jet Engines: Introduction to Paper Airplanes"
        };

        static void Main(string[] args)
        {
            var consoleClassSchedule = (!args.Any()) ? new ClassSchedule(TestListOfCourses) : new ClassSchedule(args);
            // Console.WriteLine(consoleClassSchedule.GetClassSchedule());
            Console.ReadLine();
        }
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DomainLogic
{
    public class ClassSchedule
    {
        private string[] _listOfCourses;

        public ClassSchedule(string[] listOfCourses)
        {
            ListOfCourses = listOfCourses;
        }

        public string[] ListOfCourses
        {
            get { return _listOfCourses; }
            set
            {
                if (!IsValidListOfCourses(value)) throw new ArgumentException("Course list contained invalid entries");
                _listOfCourses = value;
            }
        }

        private bool IsValidListOfCourses(string[] courses)
        {
            var rgx = new Regex(": ");
            return courses.All(course => rgx.Matches(course).Count == 1);
        }
    }
}

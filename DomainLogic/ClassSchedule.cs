using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DomainClasses;

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

        public string GetSortedClassSchedule()
        {
            var result = new List<Course>();
            foreach (var course in ListOfCourses.Select(CourseUtilities.CreateCourse))
            {
                result.AddCourse(course);
            }
            return SortCourses.Sort(result, x => x.Dependency);
        }
    }
}

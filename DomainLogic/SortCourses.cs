using System;
using System.Collections.Generic;
using System.Text;
using DomainClasses;

namespace DomainLogic
{
    public class SortCourses
    {
        public static string Sort(IEnumerable<Course> courseList, Func<Course, Course> getDependencies)
        {
            var result = new StringBuilder();
            var visited = new Dictionary<string, bool>();

            foreach (var course in courseList)
            {
                Visit(course, getDependencies, result, visited);
            }

            return result.ToString();
        }

        private static void Visit(Course course, Func<Course, Course> getDependencies, StringBuilder sorted, Dictionary<string, bool> visited)
        {
            if (visited.ContainsKey(course.Title)) return;

            visited[course.Title] = true;
            var dependency = getDependencies(course);
            if (dependency != null) Visit(dependency, getDependencies, sorted, visited);

            if (sorted.Length == 0) sorted.Append(course.Title);
            else sorted.Append(", " + course.Title);
        }
    }
}

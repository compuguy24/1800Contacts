using System.Collections.Generic;

namespace DomainClasses
{
    public static class CourseUtilities
    {
        public static Course CreateCourse(string course)
        {
            var title = course.Split(':')[0].Trim();
            var dependency = course.Split(':')[1].Trim();
            return string.IsNullOrEmpty(dependency) ? new Course(title, null) : new Course(title, new Course(dependency, null));
        }

        public static void AddCourse(this List<Course> courses, Course course)
        {
            courses.Add(course);
        }
    }
}

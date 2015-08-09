﻿using System.Collections.Generic;

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
            if (courses.Count > 0)
            {
                foreach (var rootCourse in courses)
                {
                    var courseInChain = rootCourse;
                    while (courseInChain.Dependency != null)
                    {
                        if (course.Dependency == null)
                        {
                            if (course.Title == courseInChain.Title || course.Title == courseInChain.Dependency.Title) return;
                        }
                        else
                        {
                            if (course.Title == courseInChain.Dependency.Title && courseInChain.Dependency.Dependency == null)
                            {
                                courseInChain.Dependency = course;
                                return;
                            }   
                        }
                        courseInChain = courseInChain.Dependency;
                    }
                }
            }
            courses.Add(course);
        }
    }
}

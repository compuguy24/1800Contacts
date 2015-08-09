using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainClasses.Test
{
    [TestClass]
    public class CourseUtilitiesTests
    {
        private string _testCourseWithNoDependency = "A: ";
        private string _testCourseWithDependency = "B: A";

        [TestMethod]
        public void GetCourseObjectFromStringWithNoDependency()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithNoDependency);
            Assert.AreEqual("A", course.Title);
            Assert.IsNull(course.Dependency);
        }

        [TestMethod]
        public void GetCourseObjectFromStringWithDependency()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithDependency);
            Assert.AreEqual("B", course.Title);
            Assert.IsNotNull(course.Dependency);
            Assert.AreEqual("A", course.Dependency.Title);
            Assert.IsNull(course.Dependency.Dependency);
        }

        [TestMethod]
        public void AddToEmptyLinkedList()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithNoDependency);
            var courses = new List<Course>();
            courses.AddCourse(course);
            Assert.AreEqual(1, courses.Count);
            Assert.AreEqual("A", courses[0].Title);
            Assert.IsNull(courses[0].Dependency);
        }

        [TestMethod]
        public void AddToLinkedListWithSingleMatchingEntry()
        {
            var courses = new List<Course>();
            var course = CourseUtilities.CreateCourse(_testCourseWithDependency);
            courses.AddCourse(course);
            course = CourseUtilities.CreateCourse(_testCourseWithNoDependency);
            courses.AddCourse(course);
            Assert.AreEqual(1, courses.Count);
            Assert.AreEqual("B", courses[0].Title);
            Assert.AreEqual("A", courses[0].Dependency.Title);
            Assert.IsNull(courses[0].Dependency.Dependency);
        }
    }
}

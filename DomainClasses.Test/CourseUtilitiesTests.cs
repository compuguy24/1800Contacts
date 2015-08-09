using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainClasses.Test
{
    [TestClass]
    public class CourseUtilitiesTests
    {
        private string _testCourseWithNoDependency = "A: ";
        private string _testCourseWithDependency = "B: A";
        private string _testNonMatchingEntry = "X: Y";
        private string _testPartialMatchingDependencyEntry = "A: C";
        private List<Course> _testCourses;
            
        [TestInitialize]
        public void Setup()
        {
            _testCourses = new List<Course>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testCourses = null;
        }

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
            _testCourses.AddCourse(course);
            Assert.AreEqual(1, _testCourses.Count);
            Assert.AreEqual("A", _testCourses[0].Title);
            Assert.IsNull(_testCourses[0].Dependency);
        }

        [TestMethod]
        public void AddToLinkedListWithSingleMatchingEntry()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithDependency);
            _testCourses.AddCourse(course);
            course = CourseUtilities.CreateCourse(_testCourseWithNoDependency);
            _testCourses.AddCourse(course);
            Assert.AreEqual(1, _testCourses.Count);
            Assert.AreEqual("B", _testCourses[0].Title);
            Assert.AreEqual("A", _testCourses[0].Dependency.Title);
            Assert.IsNull(_testCourses[0].Dependency.Dependency);
        }

        [TestMethod]
        public void AddToLinkedListWithSingleNonMatchingEntry()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithDependency);
            _testCourses.AddCourse(course);
            course = CourseUtilities.CreateCourse(_testNonMatchingEntry);
            _testCourses.AddCourse(course);
            Assert.AreEqual(2, _testCourses.Count);

            Assert.AreEqual("B", _testCourses[0].Title);
            Assert.AreEqual("A", _testCourses[0].Dependency.Title);
            Assert.IsNull(_testCourses[0].Dependency.Dependency);

            Assert.AreEqual("X", _testCourses[1].Title);
            Assert.AreEqual("Y", _testCourses[1].Dependency.Title);
            Assert.IsNull(_testCourses[1].Dependency.Dependency);
        }

        [TestMethod]
        public void AddToLinkedListOnRightOfChain()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithDependency);
            _testCourses.AddCourse(course);
            course = CourseUtilities.CreateCourse(_testPartialMatchingDependencyEntry);
            _testCourses.AddCourse(course);
            Assert.AreEqual(1, _testCourses.Count);

            Assert.AreEqual("B", _testCourses[0].Title);
            Assert.AreEqual("A", _testCourses[0].Dependency.Title);
            Assert.IsNotNull(_testCourses[0].Dependency.Dependency);

            Assert.AreEqual("C", _testCourses[0].Dependency.Dependency.Title);
            Assert.IsNull(_testCourses[0].Dependency.Dependency.Dependency);
        }

        [TestMethod]
        public void AddToLinkedListOnLeftOfChain()
        {
            var course = CourseUtilities.CreateCourse(_testPartialMatchingDependencyEntry);
            _testCourses.AddCourse(course);
            course = CourseUtilities.CreateCourse(_testCourseWithDependency);
            _testCourses.AddCourse(course);
            Assert.AreEqual(1, _testCourses.Count);

            Assert.AreEqual("B", _testCourses[0].Title);
            Assert.AreEqual("A", _testCourses[0].Dependency.Title);
            Assert.IsNotNull(_testCourses[0].Dependency.Dependency);

            Assert.AreEqual("C", _testCourses[0].Dependency.Dependency.Title);
            Assert.IsNull(_testCourses[0].Dependency.Dependency.Dependency);
        }

        [TestMethod]
        public void AddToRightOfChainPartialNode()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithNoDependency);
            _testCourses.AddCourse(course);
            course = CourseUtilities.CreateCourse(_testPartialMatchingDependencyEntry);
            _testCourses.AddCourse(course);
            Assert.AreEqual(1, _testCourses.Count);

            Assert.AreEqual("A", _testCourses[0].Title);
            Assert.AreEqual("C", _testCourses[0].Dependency.Title);
            Assert.IsNull(_testCourses[0].Dependency.Dependency);
        }
    }
}

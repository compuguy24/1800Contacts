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
    }
}

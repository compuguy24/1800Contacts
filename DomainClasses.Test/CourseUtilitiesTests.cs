using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainClasses.Test
{
    [TestClass]
    public class CourseUtilitiesTests
    {
        private string _testCourseWithNoDependency = "A: ";

        [TestMethod]
        public void GetCourseObjectFromStringWithNoDependency()
        {
            var course = CourseUtilities.CreateCourse(_testCourseWithNoDependency);
        }
    }
}

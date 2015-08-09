using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainClasses.Test
{
    [TestClass]
    public class CourseTests
    {
        private Course _testCourse;
        
        [TestInitialize]
        public void Setup()
        {
            _testCourse = new Course("Test", null);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testCourse = null;
        }

        [TestMethod]
        public void CourseNodeWithNoDependency()
        {
            Assert.IsNotNull(_testCourse);
            Assert.AreEqual("Test", _testCourse.Title);
            Assert.IsNull(_testCourse.Dependency);
        }

        [TestMethod]
        public void CourseNodeWithDependency()
        {
            _testCourse.Dependency = new Course("TestDependency", null);
            Assert.IsNotNull(_testCourse);
            Assert.AreEqual("Test", _testCourse.Title);
            Assert.IsNotNull(_testCourse.Dependency);
            Assert.AreEqual("TestDependency", _testCourse.Dependency.Title);
            Assert.IsNull(_testCourse.Dependency.Dependency);
        }
    }
}

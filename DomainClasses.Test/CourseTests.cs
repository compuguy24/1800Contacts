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
    }
}

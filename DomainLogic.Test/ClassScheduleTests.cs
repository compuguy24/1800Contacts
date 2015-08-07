using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainLogic.Test
{
    [TestClass]
    public class ClassScheduleTests
    {
        private ClassSchedule _testClassSchedule;

        [TestInitialize]
        public void Setup()
        {
            _testClassSchedule = new ClassSchedule();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testClassSchedule = null;
        }

        [TestMethod]
        public void ConstructorAcceptsListOfCourses()
        {
            Assert.IsNotNull(_testClassSchedule);
        }
    }
}

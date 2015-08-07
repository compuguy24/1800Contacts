using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainLogic.Test
{
    [TestClass]
    public class ClassScheduleTests
    {
        private ClassSchedule _testClassSchedule;

        private readonly string[] _testListOfCoursesBasicList = {
            "Advanced Pyrotechnics: Introduction to Fire",
            "Introduction to Fire: "
        };

        [TestInitialize]
        public void Setup()
        {
            _testClassSchedule = new ClassSchedule(_testListOfCoursesBasicList);
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
            Assert.AreEqual(_testListOfCoursesBasicList[0], _testClassSchedule.ListOfCourses[0]);
        }
    }
}

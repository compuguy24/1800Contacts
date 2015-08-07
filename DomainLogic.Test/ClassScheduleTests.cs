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

        private readonly string[] _testListOfCoursesExpandedList = {
            "Introduction to Paper Airplanes: ",
            "Advanced Throwing Techniques: Introduction to Paper Airplanes",
            "History of Cubicle Siege Engines: Rubber Band Catapults 101",
            "Advanced Office Warfare: History of Cubicle Siege Engines",
            "Rubber Band Catapults 101: ",
            "Paper Jet Engines: Introduction to Paper Airplanes"
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

        [TestMethod]
        public void ListOfCoursesPropertyAcceptsListOfCourses()
        {
            _testClassSchedule.ListOfCourses = _testListOfCoursesExpandedList;
            Assert.AreEqual(_testListOfCoursesExpandedList[0], _testClassSchedule.ListOfCourses[0]);
        }
    }
}

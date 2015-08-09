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

        private readonly string[] _testListOfCoursesInvalidList = {
            "Advanced Pyrotechnics - Introduction to Fire",
            "Introduction to Fire"
        };

        private readonly string[] _testListOfCoursesMultiplePrerequisites = {
            "A: B: C: "
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ListOfCoursesPropertyCannotAcceptInvalidData()
        {
            _testClassSchedule.ListOfCourses = _testListOfCoursesInvalidList;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ListOfCoursesPropertyCannotAcceptMultiplePrequisites()
        {
            _testClassSchedule.ListOfCourses = _testListOfCoursesMultiplePrerequisites;
        }

        [TestMethod]
        public void SortClassList()
        {
            _testClassSchedule.ListOfCourses = CreateClassList();
            var sortedList = _testClassSchedule.GetSortedClassSchedule();
            Assert.AreEqual("A, B, D, C, E, F", sortedList);
        }

        private string[] CreateClassList()
        {
            return new[] { "A: ", "B: A", "C: D", "E: C", "D: ", "F: A" };
        }
    }
}

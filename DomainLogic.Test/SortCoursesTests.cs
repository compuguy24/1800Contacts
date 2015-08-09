using DomainClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainLogic.Test
{
    [TestClass]
    public class SortCoursesTests
    {
        [TestMethod]
        public void SortBasicList()
        {
            var testList = CreateBasicUnsortedList();
            var sortedList = SortCourses.Sort(testList);
            Assert.AreEqual("A, B, D, C, E, F", sortedList);
        }

        private Course[] CreateBasicUnsortedList()
        {
            var a = new Course("B", new Course("A", null));
            var b = new Course("E", new Course("C", new Course("D", null)));
            var c = new Course("F", new Course("A", null));
            return new[] { a, b, c };
        }
    }
}

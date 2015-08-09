using System.Collections.Generic;
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
            var sortedList = SortCourses.Sort(testList, x => x.Dependency);
            Assert.AreEqual("A, B, D, C, E, F", sortedList);
        }

        [TestMethod]
        public void SortComplexList()
        {
            var testList = CreateComplexUnsortedList();
            var sortedList = SortCourses.Sort(testList, x => x.Dependency);
            Assert.AreEqual("A, B, G, D, C, E, F, H", sortedList);
        }

        private static IEnumerable<Course> CreateBasicUnsortedList()
        {
            var a = new Course("B", new Course("A", null));
            var b = new Course("E", new Course("C", new Course("D", null)));
            var c = new Course("F", new Course("A", null));
            return new[] { a, b, c };
        }

        private static IEnumerable<Course> CreateComplexUnsortedList()
        {
            var a = new Course("B", new Course("A", null));
            var b = new Course("E", new Course("C", new Course("D", new Course("G", null))));
            var c = new Course("F", new Course("A", null));
            var d = new Course("H", new Course("D", null));
            return new[] { a, b, c, d };
        }
    }
}

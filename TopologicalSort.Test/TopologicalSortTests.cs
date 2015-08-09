using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReferenceTopologicalSearch;

namespace ReferenceTopologicalSort.Test
{
    [TestClass]
    public class TopologicalSortTests
    {
        [TestMethod]
        public void CanSortBasicList()
        {
            var testList = CreateBasicUnsortedList();
            var sortedList = TopologicalSort.Sort(testList, x => x.Dependencies, new ItemEqualityComparer());
            Assert.AreEqual("A", sortedList[0].Name);
            Assert.AreEqual("B", sortedList[1].Name);
            Assert.AreEqual("D", sortedList[2].Name);
            Assert.AreEqual("C", sortedList[3].Name);
            Assert.AreEqual("E", sortedList[4].Name);
            Assert.AreEqual("F", sortedList[5].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndentifyBasicCyclicDependency()
        {
            var testList = CreateBasicCyclicList();
            var sortedList = TopologicalSort.Sort(testList, x => x.Dependencies, new ItemEqualityComparer());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndentifyComplexCyclicDependency()
        {
            var testList = CreateComplexCyclicList();
            var sortedList = TopologicalSort.Sort(testList, x => x.Dependencies, new ItemEqualityComparer());
        }

        private Item[] CreateBasicUnsortedList()
        {
            var b = new Item("B", new Item("A", null));
            var d = new Item("E", new Item("C", new Item("D", null)));
            var f = new Item("F", new Item("A"));
            return new[] { b, d, f };
        }

        private Item[] CreateBasicCyclicList()
        {
            var a = new Item("B", new Item("A", new Item("B", null)));
            return new[] { a };
        }

        private Item[] CreateComplexCyclicList()
        {
            var a = new Item("A", new Item("C", new Item("B", new Item("A"))));
            return new[] { a };
        }
    }
}

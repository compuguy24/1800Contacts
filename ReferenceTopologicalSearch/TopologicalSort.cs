using System;
using System.Collections.Generic;

namespace ReferenceTopologicalSearch
{
    //referenced http://www.codeproject.com/Articles/869059/Topological-sorting-in-Csharp
    public static class TopologicalSort
    {
        public static IList<T> Sort<T>(IEnumerable<T> courseList, Func<T, IEnumerable<T>> getDependencies, IEqualityComparer<T> comparer = null )
        {
            var sorted = new List<T>();
            var visited = new Dictionary<T, bool>(comparer);

            foreach (var course in courseList)
            {
                Visit(course, getDependencies, sorted, visited);
            }

            return sorted;
        }

        public static void Visit<T>(T course, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
        {
            bool inProcess;
            var marked = visited.TryGetValue(course, out inProcess);

            if (!marked)
            {
                visited[course] = true;

                var dependencies = getDependencies(course);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        Visit(dependency, getDependencies, sorted, visited);
                    }
                }

                visited[course] = false;
                sorted.Add(course);
            }
            else
            {
                if (inProcess)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
        }
    }

    public class ItemEqualityComparer : EqualityComparer<Item>
    {
        public override bool Equals(Item x, Item y)
        {
            return (x == null && y == null) || (x != null && y != null && x.Name == y.Name);
        }

        public override int GetHashCode(Item obj)
        {
            return obj == null ? 0 : obj.Name.GetHashCode();
        }
    }

    public class Item
    {
        public string Name { get; private set; }
        public Item[] Dependencies { get; private set; }

        public Item(string name, params Item[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }
    }
}

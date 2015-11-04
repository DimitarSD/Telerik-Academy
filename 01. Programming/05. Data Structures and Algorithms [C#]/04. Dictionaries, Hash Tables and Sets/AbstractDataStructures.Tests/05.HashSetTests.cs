namespace AbstractDataStructures.Tests
{
    using HashSet;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class HashSetTests
    {
        [TestMethod]
        public void TestAddMethod()
        {
            var hashedSet = new HashedSet<int>();
            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsFalse(hashedSet.Add(2));
            Assert.AreEqual(2, hashedSet.Count);
        }

        [TestMethod]
        public void TestUnionMethod()
        {
            var hashedSet = new HashedSet<int>();

            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.AreEqual(2, hashedSet.Count);

            int[] unionArray = { 2, 3, 4, 5 };
            hashedSet.UnionWith(unionArray);

            Assert.AreEqual(5, hashedSet.Count);
            CollectionAssert.AreEqual(hashedSet.Keys.ToList(), new List<int>() { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void TestIntersectMethod()
        {
            var hashedSet = new HashedSet<int>();

            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsTrue(hashedSet.Add(3));
            Assert.IsTrue(hashedSet.Add(4));
            Assert.AreEqual(4, hashedSet.Count);

            int[] intersectArray = { 2, 3 };
            hashedSet.IntersectWith(intersectArray);

            Assert.AreEqual(2, hashedSet.Count);
            CollectionAssert.AreEqual(hashedSet.Keys.ToList(), new List<int>() { 2, 3 });
        }

        [TestMethod]
        public void TestCountMethod()
        {
            var hashedSet = new HashedSet<int>();

            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsFalse(hashedSet.Add(2));
            Assert.IsTrue(hashedSet.Add(4));

            Assert.AreEqual(3, hashedSet.Count);
        }

        [TestMethod]
        public void TestContainsMethod()
        {
            var hashedSet = new HashedSet<int>();
            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsTrue(hashedSet.Add(3));
            Assert.IsTrue(hashedSet.Add(4));
            Assert.AreEqual(4, hashedSet.Count);

            Assert.IsTrue(hashedSet.Contains(3));
            Assert.IsTrue(hashedSet.Contains(4));

            Assert.IsFalse(hashedSet.Contains(-5));
            Assert.IsFalse(hashedSet.Contains(14));
        }

        [TestMethod]
        public void TestRemoveMethod()
        {
            var hashedSet = new HashedSet<int>();
            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsTrue(hashedSet.Add(3));
            Assert.IsTrue(hashedSet.Add(4));
            Assert.AreEqual(4, hashedSet.Count);

            Assert.IsTrue(hashedSet.Remove(3));
            Assert.IsTrue(hashedSet.Remove(4));

            Assert.IsFalse(hashedSet.Remove(-5));
            Assert.IsFalse(hashedSet.Remove(14));
        }

        [TestMethod]
        public void TestClearMethod()
        {
            var hashedSet = new HashedSet<int>();
            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsTrue(hashedSet.Add(3));
            Assert.IsTrue(hashedSet.Add(4));

            Assert.AreEqual(4, hashedSet.Count);
            hashedSet.Clear();
            Assert.AreEqual(0, hashedSet.Count);

            Assert.IsFalse(hashedSet.Contains(1));
            Assert.IsFalse(hashedSet.Contains(2));
            Assert.IsTrue(hashedSet.Add(3));
            Assert.IsTrue(hashedSet.Add(4));
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            var hashedSet = new HashedSet<int>();
            Assert.IsTrue(hashedSet.Add(1));
            Assert.IsTrue(hashedSet.Add(2));
            Assert.IsTrue(hashedSet.Add(3));
            Assert.IsTrue(hashedSet.Add(4));

            var collection = new List<int>();

            foreach (var item in hashedSet.Keys)
            {
                collection.Add(item);
            }

            Assert.AreEqual(collection.Count, hashedSet.Keys.Count());
            CollectionAssert.AreEqual(collection.OrderBy(a => a).ToList(), hashedSet.Keys.OrderBy(a => a).ToList());
        }
    }
}

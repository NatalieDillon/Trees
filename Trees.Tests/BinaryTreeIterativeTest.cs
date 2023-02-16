using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Trees.Classes;

namespace Trees.Tests
{
    [TestClass]
    public class BinaryTreeIterativeTest
    {
        [TestMethod]
        public void TestInOrder()
        {
            List<int> values = new() { 12, 7, 22, 13, 19, 32, 8, 5 };
            BinaryTreeIterative<int> tree = new BinaryTreeIterative<int>(10);
            tree.Add(values);
            values.Add(10);
            values.Sort();
            List<int> nodes = new List<int>();
            tree.InOrder(nodes);
            CollectionAssert.AreEqual(values, nodes);
        }
    }
}
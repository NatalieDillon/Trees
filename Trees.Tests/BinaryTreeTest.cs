using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Trees.Classes;

namespace Trees.Tests
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void TestInOrder()
        {
            List<int> values = new() { 12, 7, 22, 13, 19, 32, 8, 5 };
            BinaryTree<int> tree = new(10);
            tree.Add(values);
            values.Add(10);
            values.Sort();
            List<int> nodes = new();
            tree.InOrder(nodes);
            CollectionAssert.AreEqual(values, nodes);
        }


        [TestMethod]
        public void TestFind()
        {
            List<int> values = new() { 12, 7, 22, 13, 19, 32, 8, 5 };
            BinaryTree<int> tree = new(10);
            tree.Add(values);
            Assert.IsTrue(tree.Contains(13));
            Assert.IsFalse(tree.Contains(98));
        }


        [TestMethod]
        public void TestRemoveNodeWithNoChildren()
        {
            List<int> values = new() { 7, 22, 13, 19, 32, 8, 5 };
            BinaryTree<int> tree = new(12);
            tree.Add(values);
            Assert.IsTrue(tree.Contains(8));
            tree.Remove(8);
            Assert.IsFalse(tree.Contains(8));
            List<int> nodes = new();
            tree.InOrder(nodes);
            List<int> expectedNodes = new() { 5, 7, 12, 13, 19, 22, 32 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [TestMethod]
        public void TestRemoveNodeWithOneChild()
        {
            List<int> values = new() { 7, 22, 13, 19, 32, 8, 5 };
            BinaryTree<int> tree = new(12);
            tree.Add(values);
            Assert.IsTrue(tree.Contains(13));
            tree.Remove(13);
            Assert.IsFalse(tree.Contains(13));
            List<int> nodes = new();
            tree.InOrder(nodes);
            List<int> expectedNodes = new() { 5, 7, 8, 12, 19, 22, 32 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [TestMethod]
        public void TestRemoveNodeWithTwoChildren()
        {
            List<int> values = new() { 7, 22, 13, 19, 32, 8, 5, 27, 80, 30, 25 };
            BinaryTree<int> tree = new(12);
            tree.Add(values);
            Assert.IsTrue(tree.Contains(22));
            tree.Remove(22);
            Assert.IsFalse(tree.Contains(22));
            List<int> nodes = new();
            tree.InOrder(nodes);
            List<int> expectedNodes = new() { 5, 7, 8, 12, 13, 19, 25, 27, 30, 32, 80 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [TestMethod]
        public void TestPreOrder()
        {
            List<int> values = new() { 12, 7, 22, 13, 19, 32, 8, 5 };
            BinaryTree<int> tree = new(10);
            tree.Add(values);
            List<int> nodes = new();
            tree.PreOrder(nodes);
            List<int> expectedNodes = new() { 10, 7, 5, 8, 12, 22, 13, 19, 32 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [TestMethod]
        public void TestPostOrder()
        {
            List<int> values = new() { 12, 7, 22, 13, 19, 32, 8, 5 };
            BinaryTree<int> tree = new(10);
            tree.Add(values);
            List<int> nodes = new();
            tree.PostOrder(nodes);
            List<int> expectedNodes = new() { 5, 8, 7, 19, 13, 32, 22, 12, 10 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [TestMethod]
        public void TestBreadthFirst()
        {
            List<string> values = new() { "R", "A", "Q", "C", "B", "Z", "P" };
            BinaryTree<string> tree = new("G");
            tree.Add(values);
            List<string> nodes = tree.BreadthFirst();
            List<string> expected = new() { "G", "A", "R", "C", "Q", "Z", "B", "P" };
            CollectionAssert.AreEqual(expected, nodes);
        }


        [TestMethod]
        public void TestBreadthFirstInt()
        {
            List<int> values = new() { 2, 12, 14, 7, 4, 98 };
            BinaryTree<int> tree = new(9);
            tree.Add(values);
            List<int> nodes = tree.BreadthFirst();
            List<int> expected = new() { 9, 2, 12, 7, 14, 4, 98};
            CollectionAssert.AreEqual(expected, nodes);
        }
    }
}
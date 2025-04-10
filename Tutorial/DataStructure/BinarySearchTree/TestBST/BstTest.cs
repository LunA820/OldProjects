using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using BinarySearchTree;

namespace TestBST
{
    [TestClass]
    public class BstTest
    {
        [TestMethod]
        public void CreateTreeTest()
        {
            BST T = new BST(1);
            Node n = T.getNode(1);
            Assert.IsTrue(n.getX() == 1);

            Node n2 = T.getNode(2);
            Assert.IsTrue(n2 == null);
        }

        [TestMethod]
        public void AddNodeTest()
        {
            BST T = new BST(1);

            // Before add, tree doesn't have node(2)
            Node n = T.getNode(2);
            Assert.IsTrue(n == null);

            // After add
            T.add(2);
            n = T.getNode(2);
            Assert.IsTrue(n.getX() == 2);
        }

        [TestMethod]
        public void SizeTest()
        {
            BST T = new BST(1);
            Assert.IsTrue(T.getSize() == 1);
            T.add(1);
            Assert.IsTrue(T.getSize() == 2);
            T.add(9);
            Assert.IsTrue(T.getSize() == 3);
            T.remove(9);
            Assert.IsTrue(T.getSize() == 2);
        }

        [TestMethod]
        public void MinMaxTest()
        {
            // Create a new BST: 1, 5, 6, 7, 9
            BST tree = new BST(7);
            tree.add(5); tree.add(9);
            tree.add(6); tree.add(1);

            // Min = 1, Max = 9
            Assert.IsTrue(tree.getMin().getX() == 1);
            Assert.IsTrue(tree.getMax().getX() == 9);

            // Add new nodes 11, -1, min = -1, max = 11
            tree.add(-1); tree.add(11);
            Assert.IsTrue(tree.getMin().getX() == -1);
            Assert.IsTrue(tree.getMax().getX() == 11);
        }

        [TestMethod]
        public void TraversalTest()
        {
            // Create a new BST
            BST tree = new BST(7);
            Node n5 = tree.add(5); Node n9 = tree.add(9);
            Node n6 = tree.add(6); Node n1 = tree.add(1);
            Node n8 = tree.add(8); Node n11 = tree.add(11);
            Node n10 = tree.add(10); Node n12 = tree.add(12);

            // Traversal T = list of all nodes within BST
            ArrayList T = tree.traversal();
            Assert.IsTrue(T.Count == 9);
            Assert.IsTrue(T.Contains(n5));
            Assert.IsTrue(T.Contains(n9));
            Assert.IsTrue(T.Contains(n6));
            Assert.IsTrue(T.Contains(n1));
            Assert.IsTrue(T.Contains(n8));
            Assert.IsTrue(T.Contains(n11));
            Assert.IsTrue(T.Contains(n10));
            Assert.IsTrue(T.Contains(n12));
        }
    }
}

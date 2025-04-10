using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchTree;


namespace TestBST
{
    [TestClass]
    public class ParentTest
    {
        [TestMethod]
        public void ParentOfValueTest()
        {
            // Create a new BST
            BST tree = new BST(7);
            tree.add(5); Node n9 = tree.add(9);
            tree.add(6); tree.add(1);
            tree.add(8); Node n11 = tree.add(11);
            tree.add(10); tree.add(12);

            // Check parents
            Node p1 = tree.getParent(9);
            Assert.IsTrue(p1 == tree.getRoot());
            Node p2 = tree.getParent(11);
            Assert.IsTrue(p2 == n9);
            Node p3 = tree.getParent(12);
            Assert.IsTrue(p3 == n11);
            Node p4 = tree.getParent(8);
            Assert.IsTrue(p4 == n9);
            Node p5 = tree.getParent(10);
            Assert.IsTrue(p5 == n11);
        }

        [TestMethod]
        public void ParentOfNodeTest()
        {
            // Create a new BST
            BST tree = new BST(7);
            Node n5 = tree.add(5); Node n9 = tree.add(9);

            // Root = parent of n5 & n9
            Assert.IsTrue(tree.getRoot() == tree.getParent(n5));
            Assert.IsTrue(tree.getRoot() == tree.getParent(n9));

            // n5 = parent of n1 & n6
            Node n6 = tree.add(6); Node n1 = tree.add(1);
            Assert.IsTrue(n5 == tree.getParent(n1));
            Assert.IsTrue(n5 == tree.getParent(n6));
        }
    }
}

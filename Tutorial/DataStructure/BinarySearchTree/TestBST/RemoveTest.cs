using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchTree;


namespace TestBST
{
    [TestClass]
    public class RemoveTest
    {
        [TestMethod]
        public void RemoveLeafTest()
        {
            BST tree = new BST(7);
            tree.add(5); tree.add(9);
            tree.add(1); tree.add(6);

            // Check nodes exist before removal
            Assert.IsTrue(tree.getNode(5) != null);
            Assert.IsTrue(tree.getNode(9) != null);
            Assert.IsTrue(tree.getNode(1) != null);
            Assert.IsTrue(tree.getNode(6) != null);
            
            // Remove node 1 & 6
            tree.remove(1); tree.remove(6);
            Assert.IsTrue(tree.getNode(1) == null);
            Assert.IsTrue(tree.getNode(6) == null);

            // Remove leaf node 5 & 9
            tree.remove(5); tree.remove(9);
            Assert.IsTrue(tree.getNode(5) == null);
            Assert.IsTrue(tree.getNode(9) == null);
        }

        [TestMethod]
        public void RmOneChildNodeTest()
        {
            // Node 5 has 1 child
            BST tree = new BST(7);
            tree.add(5); tree.add(9);
            tree.add(1); 

            // Check nodes exist before removal
            Assert.IsTrue(tree.getNode(5) != null);
            Assert.IsTrue(tree.getNode(9) != null);
            Assert.IsTrue(tree.getNode(1) != null);

            // Remove node 5
            tree.remove(5); 
            Assert.IsTrue(tree.getNode(5) == null);

            // Check other nodes still exist
            Assert.IsTrue(tree.getNode(9) != null);
            Assert.IsTrue(tree.getNode(1) != null);
        }

        [TestMethod]
        public void RmTwoChildrenNodeTest()
        {
            // Node 9 has 2 children: node8(leaf), node11(subtree)
            BST tree = new BST(7);
            tree.add(5); tree.add(9);
            tree.add(1); tree.add(6);
            Node n8 = tree.add(8); Node n11 = tree.add(11);
            Node n10 = tree.add(10); Node n12 = tree.add(12);

            // Check nodes exist before removal
            Assert.IsTrue(tree.getNode(7) != null);
            Assert.IsTrue(tree.getNode(5) != null);
            Assert.IsTrue(tree.getNode(9) != null);
            Assert.IsTrue(tree.getNode(1) != null);
            Assert.IsTrue(tree.getNode(6) != null);
            Assert.IsTrue(tree.getNode(8) != null);
            Assert.IsTrue(tree.getNode(11) != null);
            Assert.IsTrue(tree.getNode(10) != null);
            Assert.IsTrue(tree.getNode(12) != null);

            // Remove node 9
            tree.remove(9);
            Assert.IsTrue(tree.getNode(9) == null); // Node 9 is removed

            // Other nodes still exist
            Assert.IsTrue(tree.getNode(7) != null);
            Assert.IsTrue(tree.getNode(5) != null);
            Assert.IsTrue(tree.getNode(1) != null);
            Assert.IsTrue(tree.getNode(6) != null);
            Assert.IsTrue(tree.getNode(8) != null);
            Assert.IsTrue(tree.getNode(11) != null);
            Assert.IsTrue(tree.getNode(10) != null);
            Assert.IsTrue(tree.getNode(12) != null);

            // Check attachment
            Assert.IsTrue(tree.getParent(n11) == tree.getRoot());
            Assert.IsTrue(tree.getParent(n8) == n10);
            Assert.IsTrue(tree.getParent(n10) == n11);
            Assert.IsTrue(tree.getParent(n12) == n11);
        }

        [TestMethod]
        public void RmEmptyTest()
        {
            // Remove a value that doesn't exist
            BST tree = new BST(1);
            tree.remove(9);

            // Removing root has no effect
            Node n = tree.getRoot();
            Node n2 = tree.getNode(1);
            Assert.IsTrue(n == n2);
            Assert.IsTrue(n != null);
            Assert.IsTrue(n.getX() == 1);
        }

        [TestMethod]
        public void RmRootTest()
        {
            BST tree = new BST(1);
            tree.remove(1);

            // Removing root has no effect
            Node n = tree.getRoot();
            Node n2 = tree.getNode(1);
            Assert.IsTrue(n == n2);
            Assert.IsTrue(n != null);
            Assert.IsTrue(n.getX() == 1);
        }
    }
}

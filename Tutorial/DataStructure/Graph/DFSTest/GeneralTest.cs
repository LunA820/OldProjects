using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Graph;


namespace GraphTest
{
    [TestClass]
    public class GeneralTest
    {
        [TestMethod]
        public void AddNodeTest()
        {
            GraphAPI G = new GraphAPI();

            // Add Node(1)
            Node n1 = G.addNode(1);
            ArrayList t = G.getAllNodes();
            Assert.IsTrue(t.Count == 1);
            Assert.IsTrue(t[0] == n1);

            // Add repeat node should fail
            Node n1_2 = G.addNode(1);
            Assert.IsTrue(n1_2 == null);
            t = G.getAllNodes();
            Assert.IsTrue(t.Count == 1);
            Assert.IsTrue(t[0] == n1);  // Remains unchanged

            // Add Node(2)
            Node n2 = G.addNode(2);
            t = G.getAllNodes();
            Assert.IsTrue(t.Count == 2);
            Assert.IsTrue(t[1] == n2);
        }


        [TestMethod]
        public void linkTest()
        {
            GraphAPI G = new GraphAPI();
            G.addNode(1);
            G.addNode(2);

            // Before linking 1 and 2
            Assert.IsFalse(G.isConnected(1, 2));
            G.link(1, 2);
            Assert.IsTrue(G.isConnected(1, 2));

            // Add node 3 & link it to node 1
            G.addNode(3);
            G.link(1, 3);
            Assert.IsTrue(G.isConnected(1, 3));
            Assert.IsTrue(G.isConnected(2, 3));
        }
    }

    
}

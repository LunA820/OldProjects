using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Graph;

namespace PathTest
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void DfsTraversalTest()
        {
            // Add node 1-6 to Graph
            GraphAPI G = new GraphAPI();
            Node n1 = G.addNode(1); Node n2 = G.addNode(2); Node n3 = G.addNode(3);
            Node n4 = G.addNode(4); Node n5 = G.addNode(5); Node n6 = G.addNode(6);

            // Connect Graph & Add nodes 7-9 that is not connected to Node1
            G.link(1, 2); G.link(1, 5); G.link(1, 4);
            G.link(2, 5); G.link(2, 3);
            G.link(6, 4);
            Node n7 = G.addNode(7); Node n8 = G.addNode(8); Node n9 = G.addNode(9);

            // Start testing
            ArrayList T = G.dfs_traversal(1);

            // T should contains node 1-6
            Assert.IsTrue(T.Count == 6);
            Assert.IsTrue(T.Contains(n1));
            Assert.IsTrue(T.Contains(n2));
            Assert.IsTrue(T.Contains(n3));
            Assert.IsTrue(T.Contains(n4));
            Assert.IsTrue(T.Contains(n5));
            Assert.IsTrue(T.Contains(n6));
            
            // T should not contains node 7-9
            Assert.IsFalse(T.Contains(n7));
            Assert.IsFalse(T.Contains(n8));
            Assert.IsFalse(T.Contains(n9));
        }

        [TestMethod]
        public void BfsTraversalTest()
        {
            // Add node 1-6 to Graph
            GraphAPI G = new GraphAPI();
            Node n1 = G.addNode(1); Node n2 = G.addNode(2); Node n3 = G.addNode(3);
            Node n4 = G.addNode(4); Node n5 = G.addNode(5); Node n6 = G.addNode(6);

            // Connect Graph & Add nodes 7-9 that is not connected to Node1
            G.link(1, 2); G.link(1, 5); G.link(1, 4);
            G.link(2, 5); G.link(2, 3);
            G.link(6, 4);
            Node n7 = G.addNode(7); Node n8 = G.addNode(8); Node n9 = G.addNode(9);

            // Start testing
            ArrayList T = G.bfs_traversal(1);

            // T should contains node 1-6
            Assert.IsTrue(T.Count == 6);
            Assert.IsTrue(T.Contains(n1));
            Assert.IsTrue(T.Contains(n2));
            Assert.IsTrue(T.Contains(n3));
            Assert.IsTrue(T.Contains(n4));
            Assert.IsTrue(T.Contains(n5));
            Assert.IsTrue(T.Contains(n6));

            // T should not contains node 7-9
            Assert.IsFalse(T.Contains(n7));
            Assert.IsFalse(T.Contains(n8));
            Assert.IsFalse(T.Contains(n9));
        }


        [TestMethod]
        public void BfsPathTest()
        {
            // Add node 1-11 to Graph
            GraphAPI G = new GraphAPI();
            Node n1 = G.addNode(1); Node n2 = G.addNode(2); Node n3 = G.addNode(3);
            Node n4 = G.addNode(4); Node n5 = G.addNode(5); Node n6 = G.addNode(6);
            Node n7 = G.addNode(7); Node n8 = G.addNode(8); Node n9 = G.addNode(9);
            Node n10 = G.addNode(10); Node n11 = G.addNode(11);

            // Connect Graph
            G.link(1, 2); G.link(1, 5); G.link(1, 4);
            G.link(2, 5); G.link(2, 3);
            G.link(3, 8); G.link(3, 9);
            G.link(9, 10); G.link(9, 7);
            G.link(6, 7); G.link(6, 4);
            G.link(4, 11);

            // Path should be n4 -> n11 (Adj. nodes)
            ArrayList p0 = G.find_bfs_path(4, 11);
            Assert.IsTrue(p0.Count == 2);
            Assert.IsTrue(p0[0] == n4);
            Assert.IsTrue(p0[1] == n11);

            // Path should be n1 -> n2 -> n3 -> n8
            ArrayList p1 = G.find_bfs_path(1, 8);
            Assert.IsTrue(p1.Count == 4);
            Assert.IsTrue(p1[0] == n1);
            Assert.IsTrue(p1[1] == n2);
            Assert.IsTrue(p1[2] == n3);
            Assert.IsTrue(p1[3] == n8);

            // Path should be n10 -> n9 -> n7 -> n6
            ArrayList p2 = G.find_bfs_path(10, 6);
            Assert.IsTrue(p2.Count == 4);
            Assert.IsTrue(p2[0] == n10);
            Assert.IsTrue(p2[1] == n9);
            Assert.IsTrue(p2[2] == n7);
            Assert.IsTrue(p2[3] == n6);
        }

        [TestMethod]
        public void DfsPathTest()
        {
            // Add node 1-11 to Graph
            GraphAPI G = new GraphAPI();
            Node n1 = G.addNode(1); Node n2 = G.addNode(2); Node n3 = G.addNode(3);
            Node n4 = G.addNode(4); Node n5 = G.addNode(5); Node n6 = G.addNode(6);
            Node n7 = G.addNode(7); Node n8 = G.addNode(8); Node n9 = G.addNode(9);
            Node n10 = G.addNode(10); Node n11 = G.addNode(11);

            // Connect Graph
            G.link(1, 2); G.link(1, 5); G.link(1, 4);
            G.link(2, 5); G.link(2, 3);
            G.link(3, 8); G.link(3, 9);
            G.link(9, 10); G.link(9, 7);
            G.link(6, 7); G.link(6, 4);
            G.link(4, 11);

            // Path should be n4 -> n11 (Adj. nodes)
            ArrayList p0 = G.find_dfs_path(4, 11);
            Assert.IsTrue(p0.Count == 2);
            Assert.IsTrue(p0[0] == n4);
            Assert.IsTrue(p0[1] == n11);

            // Path should be n1 -> n2 -> n3 -> n8
            ArrayList p1 = G.find_dfs_path(1, 8);
            Assert.IsTrue(p1.Count == 4);
            Assert.IsTrue(p1[0] == n1);
            Assert.IsTrue(p1[1] == n2);
            Assert.IsTrue(p1[2] == n3);
            Assert.IsTrue(p1[3] == n8);

            // Path should be n10 -> n9 -> n3 -> n2 -> n1 -> n4 -> n6
            ArrayList p2 = G.find_dfs_path(10, 6);
            Assert.IsTrue(p2.Count == 7);
            Assert.IsTrue(p2[0] == n10);
            Assert.IsTrue(p2[1] == n9);
            Assert.IsTrue(p2[2] == n3);
            Assert.IsTrue(p2[3] == n2);
            Assert.IsTrue(p2[4] == n1);
            Assert.IsTrue(p2[5] == n4);
            Assert.IsTrue(p2[6] == n6);
        }
    }
}

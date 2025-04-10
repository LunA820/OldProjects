using System;
using System.Collections;


namespace Graph
{
    class Program
    {
        static void Main(string[] args)
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
            Console.Write("n4 to n11: ");
            foreach (Node n in p0)
                Console.Write(n.getX() + " ");



            // Path should be n1 -> n2 -> n3 -> n8
            ArrayList p1 = G.find_dfs_path(1, 8);
            Console.Write("n1 to n8: ");
            foreach (Node n in p1)
                Console.Write(n.getX() + " ");


            // Path should be n10 -> n9 -> n7 -> n6
            ArrayList p2 = G.find_dfs_path(10, 6);
            Console.Write("n10 to n16: ");
            foreach (Node n in p2)
                Console.Write(n.getX() + " ");



        }
    }
}

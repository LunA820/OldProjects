using System;
using System.Collections;


namespace Graph
{
	public class GraphAPI
	{
		// Constructor
		private ArrayList nodes;
		public GraphAPI(){nodes = new ArrayList();}

		// Getters
		public ArrayList getAllNodes() { return nodes; }
		public Node getNode(int x){
			foreach (Node n in nodes){
				if (n.getX() == x)
					return n;
            }
			return null;
        }

		// Setters
		public Node addNode(int x){
			Node n = getNode(x);
			if (n != null) { return null; }
			n = new Node(x);
			nodes.Add(n);
			return n;
        }

		// Link node1 <-> node2 (Two way)
		public bool link(int x1, int x2)
        {
			Node n1 = getNode(x1);
			Node n2 = getNode(x2);
			if (n1 == null || n2 == null) { return false; }
			n1.addAdjNode(n2);
			n2.addAdjNode(n1);
			return true;
        }

		// Check if both nodes exist in Graph
		public bool checkExist(int x1, int x2)
        {
			Node n1 = getNode(x1);
			Node n2 = getNode(x2);
			return (n1 != null && n2 != null);
		}

		// Check if two nodes are connected
		public bool isConnected(int x1, int x2){
			if (!checkExist(x1, x2)) { return false; }
			ArrayList t = DFS.traversal(getNode(x1));
			return (t.Contains(getNode(x2)));
        }

		// Find all connected nodes of Node by DFS
		public ArrayList dfs_traversal(int x){
			Node n = getNode(x);
			if (n == null) { return new ArrayList(); }
			return DFS.traversal(n);
        }

		// Find all connected nodes of Node by BFS
		public ArrayList bfs_traversal(int x)
		{
			Node n = getNode(x);
			if (n == null) { return new ArrayList(); }
			return BFS.traversal(n);
		}


		// Find path from node 1 to node 2 (DFS)
		public ArrayList find_dfs_path(int start, int dest)
		{
			// Check if start / dest are inside the graph
			ArrayList t = new ArrayList();
			if (!checkExist(start, dest)) { return t; }
			
			// Find path by DFS
			t = DFS.traversal(getNode(start));
			return findPath(t, getNode(dest));
		}

		// Find path from node 1 to node 2 (BFS)
		public ArrayList find_bfs_path(int start, int dest)
		{
			// Check if start / dest are inside the graph
			ArrayList t = new ArrayList();
			if (!checkExist(start, dest)) { return t; }

			// Find path by BFS
			t = BFS.traversal(getNode(start));
			return findPath(t, getNode(dest));
		}



		/*
			Helper Function. Convert DFS/BFS traversal by filtering unconnected nodes:
			  1. Reverse original path
			  2. Only add node which is connected to the prev node
			  3. The first prev node is dest
		*/
		private ArrayList findPath(ArrayList traversal, Node dest)
		{
			// If start and dest are not connected, return empty array
			ArrayList path = new ArrayList();
			if (!traversal.Contains(dest)) { return path; }


			// Reverse traversal, then create previous node to check connectivity
			traversal.Reverse();
			Node Prev = null;

			// Only add node to path if it is connected to previous node
			// The first "prev" should be Destination
			foreach (Node n in traversal){

				// Found dest, add and update prev
				if (Prev != null){
					
					if (n.isConnected(Prev)){
						path.Add(n);
						Prev = n;	
					}
				}
				// Find first prev node = dest
				if (n == dest){
					path.Add(n);
					Prev = n;
				}
			}

			// Reverse path and return
			path.Reverse();
			return path;
		}
	}
}

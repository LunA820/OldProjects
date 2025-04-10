using System;
using System.Collections;


namespace Graph
{
	// Depth First Search
    public class DFS
    {
		// DFS traversal to all connected nodes from start
		public static ArrayList traversal(Node start)
		{
			ArrayList path = new ArrayList();
			DFSUtil(start, path);
			return path;
		}

		private static void DFSUtil(Node cur, ArrayList path){

			path.Add(cur);

			foreach (Node n in cur.getAdjNodes()){
				if (!path.Contains(n))
					DFSUtil(n, path);
			}
		}
	}
}

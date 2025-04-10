using System;
using System.Collections;


namespace Graph
{
    // Breath First Search
    public class BFS
    {
        // BFS traversal to all connected nodes from start
        public static ArrayList traversal(Node start)
        {
            ArrayList path = new ArrayList();
            ArrayList stack = new ArrayList();

            path.Add(start); 
            foreach(Node n in start.getAdjNodes()){
                stack.Add(n);
            }
            BFSUtil(stack, path);   // Recursive BFS
            return path;
        }

        private static void BFSUtil(ArrayList stack, ArrayList path)
        {
            // Return when stack is empty (No more node to be explored)
            if (stack.Count == 0) { return; }

            // Create a copy of stack, and visited all nodes in stack
            ArrayList cpStack = new ArrayList();
            foreach (Node n in stack){
                cpStack.Add(n);
                path.Add(n);
            }

            // Clear stack, then add all adj. nodes of nodes in stack
            stack.Clear();
            foreach(Node n in cpStack){
                foreach (Node adj in n.getAdjNodes()){
                    if (!path.Contains(adj))
                        stack.Add(adj);
                }
            }

            // Recursive path
            BFSUtil(stack, path);
        }
    }
}

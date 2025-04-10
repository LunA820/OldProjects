using System;
using System.Collections;


namespace BinarySearchTree
{
    public class BST
    {
        private Node root;
        public BST(int x) {
            root = new Node(x);
        }

        // ============================================== API
        // Getters
        public Node getRoot() { return root; }  
        public Node getNode(int x) { return getNodeUtil(x, root); }
        public Node getMax() { return getMaxUtil(root); }
        public Node getMin() { return getMinUtil(root); }
        public int getSize() { return getSizeUtil(root); }
        public Node getParent(int x) { return getParentUtil(x, root); }
        public Node getParent(Node n) { return getParentUtil(n, root); }
        public ArrayList traversal(){
            // Get nodes within BST
            ArrayList T = new ArrayList();
            visitAllNodes(T, root);
            return T;
        }

        // Add new node
        public Node add(int x){
            Node n = new Node(x);
            addUtil(root, n);
            return n;
        }

        // Remove first node with value x
        public void remove(int x) { removeUtil(x, root); }

        
        
        // ============================================== Utility Functions
        // Add Node
        private void addUtil(Node cur, Node n)
        {
            if (n.getX() >= cur.getX()) {
                if (cur.getRight() == null)
                    cur.setRight(n);
                else
                    addUtil(cur.getRight(), n);
            }

            else if (cur.getLeft() == null) { cur.setLeft(n); }
            else { addUtil(cur.getLeft(), n); }
        }

        // Remove Node
        private void removeUtil(int x, Node cur)
        {
            // Case 1: No node to be removed
            if (cur == null) { return; }

            // Case 2 (recursive): Go left or right
            if (x > cur.getX()) {removeUtil(x, cur.getRight());}
            else if (x < cur.getX()) {removeUtil(x, cur.getLeft());}

            // Case 3: Remove node
            else{
                // Cannot remove root
                if (cur == root) { return; }

                // Check whether parent is at left or right side
                Node parent = getParent(cur);
                bool parentAtLeft = (parent.getLeft() == cur);


                // Case 3.1: Leaf node
                if (cur.getLeft() == null && cur.getRight() == null){
                    if (parentAtLeft) { parent.setLeft(null); }
                    else { parent.setRight(null); }
                }

                // Case 3.2: 2 children
                else if (cur.getLeft() != null && cur.getRight() != null)
                {
                    /*
                        1. Find min() at right subtree = rightMin
                        2. Attech left subtree of node to be removed to rightMin
                     */
                    Node rightMin = getMinUtil(cur.getRight());
                    rightMin.setLeft(cur.getLeft());
                    cur.setLeft(null);

                    // Detach node to be removed from parent, attach rightMin
                    if (parentAtLeft) { parent.setLeft(cur.getRight()); }
                    else { parent.setRight(cur.getRight()); }
                 }

                // Case 3.3: 1 Child
                else if (cur.getLeft() != null){
                    if (parentAtLeft) { parent.setLeft(cur.getLeft()); }
                    else { parent.setRight(cur.getLeft()); }                        
                }
                else{
                    if (parentAtLeft) { parent.setLeft(cur.getRight()); }
                    else { parent.setRight(cur.getRight()); }                        
                }
            }
        }

        // Get parent of first node(x)
        private Node getParentUtil(int x, Node cur)
        {   // Case 1: Can't find parent
            if (cur == null) { return null; }

            // Case 2: Find parent
            if (cur.getLeft() != null){
                if (cur.getLeft().getX() == x) { return cur; }
            }
            if (cur.getRight() != null){
                if (cur.getRight().getX() == x) { return cur; }
            }

            // Case 3: Recursive cases
            if (cur.getX() > x) { return getParentUtil(x, cur.getLeft()); }
            return getParentUtil(x, cur.getRight());
        }

        // Get parent of Node n
        private Node getParentUtil(Node n, Node cur)
        {
            if (cur == null) { return null; }
            if (cur.getLeft() == n || cur.getRight() == n) { return cur; }
            if (cur.getX() > n.getX()) { return getParentUtil(n, cur.getLeft()); }
            return getParentUtil(n, cur.getRight());
        }

        // Get Node(x)
        private Node getNodeUtil(int x, Node curr)
        {
            if (curr == null) { return null; }
            if (curr.getX() == x) { return curr; }
            if (curr.getX() > x) { return getNodeUtil(x, curr.getLeft()); }
            return getNodeUtil(x, curr.getRight());
        }

        // Get min(Node) & Get max(Node)
        private Node getMinUtil(Node cur){
            if (cur.getLeft() != null) { return getMinUtil(cur.getLeft()); }
            return cur;
        }
        private Node getMaxUtil(Node cur){
            if (cur.getRight() != null) { return getMaxUtil(cur.getRight()); }
            return cur;
        }

        // Traversal all nodes
        private void visitAllNodes(ArrayList T, Node curr)
        {
            T.Add(curr);
            if (curr.getLeft() != null) { visitAllNodes(T, curr.getLeft()); }
            if(curr.getRight() != null) { visitAllNodes(T, curr.getRight()); }
        }

        // Get size of Tree
        private int getSizeUtil(Node curr){
            if (curr == null) { return 0; }
            return 1 + getSizeUtil(curr.getLeft()) + getSizeUtil(curr.getRight());
        }

        // Print an Arraylist of nodes
        public void print()
        {
            ArrayList T = traversal();
            foreach (Node n in T)
                Console.Write(n.getX() + " ");

            Console.WriteLine("");
        }

    }
}

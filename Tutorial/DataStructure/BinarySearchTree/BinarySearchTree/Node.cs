using System;
namespace BinarySearchTree
{
    public class Node
    {
        private int x;
        private Node left;
        private Node right;

        public Node(int x){
            this.x = x;
            left = null;
            right = null;
        }

        // Setters
        public void setLeft(Node n) { left = n; }
        public void setRight(Node n) { right = n; }

        // Getters
        public int getX() { return x; }
        public Node getLeft() { return left; }
        public Node getRight() { return right; }
    }
}

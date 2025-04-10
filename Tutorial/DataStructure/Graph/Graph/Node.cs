using System;
using System.Collections;


namespace Graph
{
    public class Node
    {
        private int x;
        private ArrayList adjNodes;

        public Node(int x){
            this.x = x;
            adjNodes = new ArrayList();
        }

        public void addAdjNode(Node n){
            adjNodes.Add(n);
        }
        
        public bool isConnected(Node n){
            return adjNodes.Contains(n);
        }


        // Getters
        public ArrayList getAdjNodes(){return adjNodes;}
        public int getX() { return x; }
    }
}

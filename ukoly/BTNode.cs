namespace ukoly
{
    public class BTNode
    {
        public int key;
        public int degree;
        public BTNode? parent;
        public BTNode? child;
        public BTNode? sibling;

        public BTNode(int key, int degree)
        { 
            this.key = key; 
            this.degree = degree;
        }
    }
}

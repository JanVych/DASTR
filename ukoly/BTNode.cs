namespace ukoly
{
    public class BTNode
    {
        public int key;
        public int degree;
        public BTNode? parent;
        public BTNode? children;
        public BTNode? sibling;

        public BTNode(int key)
        { 
            this.key = key; 
        }
    }
}

namespace ukoly
{
    public class BHNode
    {
        public int Key { get; set; }
        public int Degree { get; set; }
        public BHNode? Parent { get; set; }
        public BHNode? Child { get; set; }
        public BHNode? Sibling { get; set; }

        public BHNode(int key, int degree)
        { 
            Key = key; 
            Degree = degree;
        }
        public BHNode(int key)
        {
            Key = key;
            Degree = 0;
        }
    }
}

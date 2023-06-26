namespace ukoly
{
    public class FHNode
    {
        public int Key { get; set; }
        public FHNode? Parent { get; set; }
        public FHNode Left { get; set; }
        public FHNode Right { get; set; }
        public FHNode? Child { get; set; }
        public int Degree { get; set; }
        public bool Marked { get; set; }

        public FHNode(int key)
        {
            Key = key;
            Parent = null;
            Child = null;
            Left = this;
            Right = this;
            Degree = 0;
            Marked = false;
        }
    }
}

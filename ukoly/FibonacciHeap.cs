namespace ukoly
{
    public class FibonacciHeap
    {
        public FHNode? MinNode { get; private set; }

        public int NodeCount { get; private set; }

        public void FibHeapInsert(int key) => FibHeapInsert(new FHNode(key));
        public void FibHeapInsert(FHNode node)
        {
            if (MinNode != null)
            {
                node.Left = MinNode;
                node.Right = MinNode.Right;
                MinNode.Right = node;
                node.Right.Left = node;

                if (node.Key < MinNode.Key)
                {
                    MinNode = node;
                }
            }
            else
            {
                MinNode = node;
            }

            NodeCount++;
        }

        public FibonacciHeap Union(FibonacciHeap otherHeap)
        {
            FibonacciHeap newHeap = new();

            if (MinNode != null && otherHeap != null)
            {
                newHeap.MinNode = MinNode;

                if (newHeap.MinNode != null)
                {
                    if (otherHeap.MinNode != null)
                    {
                        newHeap.MinNode.Right.Left = otherHeap.MinNode.Left;
                        otherHeap.MinNode.Left.Right = newHeap.MinNode.Right;
                        newHeap.MinNode.Right = otherHeap.MinNode;
                        otherHeap.MinNode.Left = newHeap.MinNode;

                        if (otherHeap.MinNode.Key < MinNode.Key)
                        {
                            newHeap.MinNode = otherHeap.MinNode;
                        }
                    }
                }
                else
                {
                    newHeap.MinNode = otherHeap.MinNode;
                }

                newHeap.NodeCount = NodeCount + otherHeap.NodeCount;
            }

            return newHeap;
        }

        private static void BinomialLink(FHNode nodeY, FHNode nodeX)
        {
            nodeY.Left.Right = nodeY.Right;
            nodeY.Right.Left = nodeY.Left;

            nodeY.Parent = nodeX;

            if (nodeX.Child == null)
            {
                nodeX.Child = nodeY;
                nodeY.Left = nodeY;
                nodeY.Right = nodeY;
            }
            else
            {
                nodeY.Left = nodeX.Child;
                nodeY.Right = nodeX.Child.Right;
                nodeX.Child.Right = nodeY;
                nodeY.Right.Left = nodeY;
            }

            nodeX.Degree++;
            nodeY.Marked = false;
        }

        public int? FibHeapFindMin() => MinNode?.Key;
        public FHNode? FibHeapExtractMin()
        {
            if (MinNode == null) { return null; }
            FHNode minNode = MinNode;
            FHNode? node;
            FHNode tempNode;

            if (minNode != null)
            {
                int num = minNode.Degree;
                node = minNode.Child;

                while (num > 0)
                {
                    tempNode = node.Right;

                    node.Left.Right = node.Right;
                    node.Right.Left = node.Left;

                    node.Left = MinNode;
                    node.Right = MinNode.Right;
                    MinNode.Right = node;
                    node.Right.Left = node;

                    node.Parent = null;
                    node = tempNode;
                    num--;
                }

                minNode.Left.Right = minNode.Right;
                minNode.Right.Left = minNode.Left;

                if (minNode == minNode.Right)
                {
                    MinNode = null;
                }
                else
                {
                    MinNode = minNode.Right;
                    Consolidate();
                }

                NodeCount--;
            }

            return minNode;
        }

        private void Consolidate()
        {
            FHNode xNode;
            FHNode yNode;
            FHNode nextNode;
            FHNode tempNode;
            int degree;

            if (MinNode ==  null) { return; }

            int maxDegree = (int)Math.Floor(Math.Log(NodeCount) / Math.Log((1 + Math.Sqrt(5)) / 2));
            FHNode?[] degreeArray = new FHNode?[maxDegree];

            for (var i = 0; i < maxDegree; i++)
            {
                degreeArray[i] = null;
            }

            var numRoots = 0;
            xNode = MinNode;

            if (xNode != null)
            {
                numRoots++;
                xNode = xNode.Right;

                while (xNode != MinNode)
                {
                    numRoots++;
                    xNode = xNode.Right;
                }
            }

            while (numRoots > 0)
            {
                degree = xNode.Degree;
                nextNode = xNode.Right;

                while (true)
                {
                    yNode = degreeArray[degree];
                    if (yNode == null)
                    {
                        break;
                    }

                    if (xNode.Key > yNode.Key)
                    {
                        tempNode = yNode;
                        yNode = xNode;
                        xNode = tempNode;
                    }

                    BinomialLink(yNode, xNode);
                    degreeArray[degree] = null;
                    degree++;
                }

                degreeArray[degree] = xNode;
                xNode = nextNode;
                numRoots--;
            }

            MinNode = null;

            for (var i = 0; i < maxDegree; i++)
            {
                yNode = degreeArray[i];
                if (yNode == null)
                {
                    continue;
                }
                if (MinNode != null)
                {
                    yNode.Left.Right = yNode.Right;
                    yNode.Right.Left = yNode.Left;
                    yNode.Left = MinNode;
                    yNode.Right = MinNode.Right;
                    MinNode.Right = yNode;
                    yNode.Right.Left = yNode;

                    if (yNode.Key < MinNode.Key)
                    {
                        MinNode = yNode;
                    }
                }
                else
                {
                    MinNode = yNode;
                }
            }
        }
    }
}
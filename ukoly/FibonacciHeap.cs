//namespace ukoly
//{
//    public class FibonacciHeap
//    {
//        FHNode? root;
//        int nodeCount = 0;

//        public void FibHeapInsert(int key) => FibHeapInsert(this, new FHNode(key));
//        public static void FibHeapInsert(FibonacciHeap heap, FHNode node)
//        {
//            FHNode newNode = new FHNode(node.key)
//            {
//                key = node.key,
//                degree = 0,
//                parent = null,
//                child = null,
//                left = null,
//                right = null,
//                marked = false
//            };

//            // Add the new node to the root list
//            if (heap.root == null)
//            {
//                heap.root = newNode;
//                newNode.left = newNode;
//                newNode.right = newNode;
//            }
//            else
//            {
//                newNode.left = heap.root;
//                newNode.right = heap.root.right;
//                heap.root.right = newNode;
//                newNode.right.left = newNode;

//                // Update the minimum pointer if necessary
//                if (node.key < heap.root.key)
//                {
//                    heap.root = newNode;
//                }
//            }

//            heap.nodeCount++;
//        }
//        //node.degree = 0;
//        //node.marked = false;
//        //node.child = null;
//        //node.parent = null;
//        //node.left = node;
//        //node.right = node;

//        //if (heap.root == null)
//        //{
//        //    heap.root = node;
//        //}
//        //else
//        //{
//        //    heap.root.left.right = node;
//        //    node.right = heap.root;
//        //    node.left = heap.root.left;
//        //    heap.root.left = node;
//        //}
//        //if (heap.root.key > node.key)
//        //{
//        //    heap.root = node;
//        //}
//        //heap.nodeCount++;
    
//        public FibonacciHeap FibHeapUnion(FibonacciHeap other) => FibHeapUnion(this, other);
//        public static FibonacciHeap FibHeapUnion(FibonacciHeap heap1, FibonacciHeap heap2)
//        {
//            FibonacciHeap newHeap = new();

//            if (heap2.root == null)
//            {
//                newHeap.root = heap1.root;
//                newHeap.nodeCount = heap1.nodeCount;
//                return newHeap;
//            }
//            if (heap1.root == null)
//            {
//                newHeap.root = heap2.root;
//                newHeap.nodeCount = heap2.nodeCount;
//                return newHeap;
//            }

//            newHeap.root = heap1.root;
//            FHNode temp1 = newHeap.root.right;
//            FHNode temp2 = heap2.root.left;

//            newHeap.root.right.left = heap2.root.left;
//            newHeap.root.right = heap2.root;
//            heap2.root.left = newHeap.root;
//            temp2.right = temp1;

//            if (newHeap.root.key > heap2.root.key)
//            {
//                newHeap.root = heap2.root;
//            }
//            newHeap.nodeCount = heap2.nodeCount + heap1.nodeCount;
//            return newHeap;
//        }
//        public int? FibHeapMinimumKey() => FibHeapMinimum(this)?.key;
//        public static FHNode? FibHeapMinimum(FibonacciHeap heap)
//        {
//            return heap.root;
//        }

//        public int? FibHeapExtractMinKey() => FibHeapExtractMin(this)?.key;
//        public static FHNode? FibHeapExtractMin(FibonacciHeap heap)
//        {
//            FHNode? extractedNode = heap.root;

//            if (extractedNode != null)
//            {
//                FHNode? node1 = extractedNode.child;
//                FHNode? tempNode;

//                while (node1 != null)
//                {
//                    tempNode = node1.right;

//                    node1.left.right = node1.right;
//                    node1.right.left = node1.left;

//                    node1.left = extractedNode;
//                    node1.right = extractedNode.right;
//                    extractedNode.right = node1;
//                    node1.right.left = node1;

//                    node1.parent = null;
//                    node1 = tempNode;
//                }
//                extractedNode.left.right = extractedNode.right;
//                extractedNode.right.left = extractedNode.left;

//                if (extractedNode == extractedNode.right)
//                {
//                    heap.root = null;
//                }
//                else
//                {
//                    heap.root = extractedNode.right;
//                    Consolidate(heap);
//                }

//                heap.nodeCount--;
//                return extractedNode;
//            }
//            return null;
//        }

//        public static void FibHeapLink(FHNode nodeY, FHNode nodeX)
//        {
//            nodeY.left.right = nodeY.right;
//            nodeY.right.left = nodeY.left;
//            nodeY.parent = nodeX;

//            if (nodeX.child == null)
//            {
//                nodeX.child = nodeY;
//                nodeY.left = nodeY;
//                nodeY.right = nodeY;
//            }
//            else
//            {
//                nodeY.left = nodeX.child;
//                nodeY.right = nodeX.child.right;
//                nodeX.child.right = nodeY;
//                nodeY.right.left = nodeY;
//            }

//            nodeX.degree++;
//            nodeY.marked = false;
//        }

//        public static int CalculateMaxDegree(int n)
//        {
//            double phi = (1 + Math.Sqrt(5)) / 2; 

//            int maxDegree = (int)Math.Floor(Math.Log(n) / Math.Log(phi));
//            return maxDegree;
//        }
//        private static void FibonacciHeapLink(FHNode y, FHNode x)
//        {
//            y.left.right = y.right;
//            y.right.left = y.left;

//            y.parent = x;
//            if (x.child == null)
//            {
//                x.child = y;
//                y.left = y;
//                y.right = y;
//            }
//            else
//            {
//                y.left = x.child;
//                y.right = x.child.right;
//                x.child.right = y;
//                y.right.left = y;
//            }

//            x.degree++;
//            y.marked = false;
//        }
//        public static void Consolidate(FibonacciHeap heap)
//        {
//            List<FHNode> degreeTable = new List<FHNode>();
//            int maxDegree = (int)Math.Floor(Math.Log(heap.nodeCount) / Math.Log(1.618));

//            for (int i = 0; i <= maxDegree; i++)
//            {
//                degreeTable.Add(null);
//            }

//            List<FHNode> roots = new List<FHNode>();
//            FHNode current = heap.root;

//            // Collect all the roots into a list
//            do
//            {
//                roots.Add(current);
//                current = current.right;
//            } while (current != heap.root);

//            foreach (FHNode root in roots)
//            {
//                FHNode x = root;
//                int degree = x.degree;

//                while (degreeTable[degree] != null)
//                {
//                    FHNode y = degreeTable[degree];
//                    if (x.key > y.key)
//                    {
//                        FHNode temp = x;
//                        x = y;
//                        y = temp;
//                    }

//                    FibonacciHeapLink(y, x);
//                    degreeTable[degree] = null;
//                    degree++;
//                }

//                degreeTable[degree] = x;
//            }

//            heap.root = null;

//            // Reconstruct the root list
//            foreach (FHNode node in degreeTable)
//            {
//                if (node != null)
//                {
//                    if (heap.root == null)
//                    {
//                        heap.root = node;
//                    }
//                    else
//                    {
//                        node.left = heap.root;
//                        node.right = heap.root.right;
//                        heap.root.right = node;
//                        node.right.left = node;

//                        if (node.key < heap.root.key)
//                        {
//                            heap.root = node;
//                        }
//                    }
//                }
//            }
            
//            //List<FHNode?> degreeTable = new();
//            //int d = CalculateMaxDegree(heap.nodeCount);

//            //for (int i = 0; i <= d; i++)
//            //{
//            //    degreeTable.Add(null);
//            //}

//            //List<FHNode> rootNodes = new();

//            //FHNode nodeX = heap.root.right;
//            //FHNode nodeY;
//            //FHNode tempNode;
//            //rootNodes.Add(heap.root);

//            //while (nodeX != heap.root)
//            //{
//            //    rootNodes.Add(nodeX);
//            //    nodeX = nodeX.right;
//            //}

//            //foreach (FHNode rootNode in rootNodes)
//            //{
//            //    nodeX = rootNode;
//            //    int degree = nodeX.degree;

//            //    while (degreeTable[degree] != null)
//            //    {
//            //        nodeY = degreeTable[degree];
//            //        if (nodeX.key > nodeY.key)
//            //        {
//            //            tempNode = nodeX;
//            //            nodeX = nodeY;
//            //            nodeY = tempNode;
//            //        }

//            //        FibHeapLink(nodeY, nodeX);
//            //        degreeTable[degree] = null;
//            //        degree++;
//            //    }

//            //    degreeTable[degree] = nodeX;
//            //}
//            //heap.root = null;

//            //foreach (FHNode? node in degreeTable)
//            //{
//            //    if (node != null)
//            //    {
//            //        if (heap.root == null)
//            //        {
//            //            heap.root = node;
//            //        }
//            //        else
//            //        {
//            //            node.left = heap.root;
//            //            node.right = heap.root.right;

//            //            heap.root.right = node;
//            //            node.right.left = node;

//            //            if (node.key < heap.root.key)
//            //            {
//            //                heap.root = node;
//            //            }
//            //        }
//            //    }
//            //}
//        }
//    }
//}

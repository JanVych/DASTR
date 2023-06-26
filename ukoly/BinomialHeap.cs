using System.Xml.Linq;

namespace ukoly
{
    //min-heap
    internal class BinomialHeap
    {
        public BHNode? Root { get; private set; } = null;
        public  BHNode? BinomialHeapMinimum()
        {
            if (Root == null) {  return null; }
            BHNode? node = Root;
            BHNode? minNode = node;

            while (node != null) 
            {
                node = node.Sibling;
                if (node != null && minNode.Key > node.Key)
                {
                    minNode = node;
                }
            }
            return minNode;
        }

        public static void BinomialLink(BHNode node1, BHNode node2)
        {
            node1.Parent = node2;
            node1.Sibling = node2.Child;
            node2.Child = node1;
            node2.Degree++;
        }
        public static BHNode? MinNodeDegree(BHNode? node1, BHNode? node2)
        {
            if (node1 == null && node2 == null) return null;
            if (node2 == null || (node1 != null && node1.Degree < node2.Degree))
            {
                return node1;
            }
            return node2;
        }

        public BinomialHeap BinomialHeapMerge(BinomialHeap other)
        {
            BHNode? node1 = Root;
            BHNode? node2 = other.Root;
            BHNode? tempNode;
            BHNode? minNode = MinNodeDegree(node1, node2);

            BinomialHeap newHeap = new();

            if (minNode == null) return newHeap;
            if (minNode == node2)
            {
                node2 = node1;
                node1 = minNode;
            }
            while (node1 != null)
            {
                if (node1.Sibling == null) 
                {
                    node1.Sibling = node2;
                    break;
                }
                if (node2 == null )
                {
                    break;
                }
                if (node1.Sibling.Degree > node2.Degree)
                {
                    tempNode = node2;
                    node2 = node1.Sibling;
                    node1.Sibling = tempNode;
                }
                node1 = node1.Sibling;
            }
            newHeap.Root = minNode;
            return newHeap;
        }

        public BinomialHeap BinomialHeapUnion(BinomialHeap other)
        {
            BinomialHeap? newHeap = BinomialHeapMerge(other);

            if (newHeap.Root == null) return newHeap;

            BHNode? prevNode = null;
            BHNode node = newHeap.Root;
            BHNode? nextNode = node.Sibling;

            while (nextNode != null)
            {
                if (node.Degree != nextNode.Degree || (nextNode.Sibling != null && nextNode.Sibling.Degree == node.Degree))
                {
                    prevNode = node;
                    node = nextNode;
                }
                else
                {
                    if (node.Key <= nextNode.Key)
                    {
                        node.Sibling = nextNode.Sibling;
                        BinomialLink(nextNode, node);
                    }
                    else
                    {
                        if (prevNode == null)
                        {
                            newHeap.Root = nextNode;
                        }
                        else
                        {
                            prevNode.Sibling = nextNode;
                        }
                        BinomialLink(node, nextNode);
                        node = nextNode;
                    }
                }
                nextNode = node.Sibling;
            }

            return newHeap;
        }

        public void BinomialHeapInsertKey(int key) => BinomialHeapInsert(new BHNode(key));
        public void BinomialHeapInsert( BHNode node)
        {
            BinomialHeap newHeap = new();
            node.Parent = null;
            node.Sibling = null;
            node.Child = null;
            newHeap.Root = node;

            Root = BinomialHeapUnion(newHeap).Root;
        }

        public int? BinomialHeapExtractMinKey() => BinomialHeapExtractMin()?.Key;
        public BHNode? BinomialHeapExtractMin()
        {
            if (Root == null) return null;
            BHNode? node = Root;
            BHNode? minNode = node;
            BHNode? prewMinNode = null;
            BHNode? prewNode = null;

            BinomialHeap newHeap = new();
            
            BHNode? nextNode;

            while (node != null)
            { 
                if (minNode.Key > node.Key)
                {
                    prewMinNode = prewNode;
                    minNode = node;
                }
                prewNode = node;
                node = node.Sibling;
            }

            if (prewMinNode == null)
            {
                Root = minNode.Sibling;
            }
            else
            {
                prewMinNode.Sibling = minNode.Sibling;
            }

            node = minNode.Child;
            prewNode = null;

            while (node != null)
            {
                node.Parent = null;
                nextNode = node.Sibling;
                node.Sibling = prewNode;
                prewNode = node;
                node = nextNode;
            }

            newHeap.Root = prewNode;

            Root = BinomialHeapUnion(newHeap).Root;

            minNode.Degree = 0;
            minNode.Child = null;
            minNode.Sibling = null;
            return minNode;
        }
    }
}

using System.Xml.Linq;

namespace ukoly
{
    //min-heap
    internal class BinomialHeap
    {
        public BTNode? root;
        public static BTNode? BinomialHeapMinimum(BinomialHeap heap)
        {
            BTNode? node = heap.root;
            BTNode? minNode = null;
            int min = int.MaxValue;

            while (node != null) 
            {
                if (node.key < min)
                {
                    min = node.key;
                    minNode = node;
                }
                node = node.sibling;
            }
            return minNode;
        }

        public static void BinomialLink(BTNode b1, BTNode b2)
        {
            b1.parent = b2;
            b1.sibling = b2.child;
            b2.child = b1;
            b2.degree++;
        }
        public static BTNode? MinNodeDegree(BTNode? node1, BTNode? node2)
        {
            if (node1 == null && node2 == null) return null;
            if (node2 == null || (node1 != null && node1.degree < node2.degree))
            {
                return node1;
            }
            return node2;
        }

        public static BinomialHeap BinomialHeapMerge(BinomialHeap heap1, BinomialHeap heap2)
        {
            BTNode? node1 = heap1.root;
            BTNode? node2 = heap2.root;
            BTNode? tempNode = null;
            BTNode? minNode = MinNodeDegree(node1, node2);

            BinomialHeap newHeap = new();

            if (minNode == null) return newHeap;
            if (minNode == node2)
            {
                node2 = node1;
                node1 = minNode;
            }
            while (node1 != null)
            {
                if (node1.sibling == null) 
                {
                    node1.sibling = node2;
                    break;
                }
                if (node2 == null )
                {
                    break;
                }
                if (node1.sibling.degree > node2.degree)
                {
                    tempNode = node2;
                    node2 = node1.sibling;
                    node1.sibling = tempNode;
                }
                node1 = node1.sibling;
            }
            newHeap.root = minNode;
            return newHeap;
        }

        public BinomialHeap BinomialHeapUnion(BinomialHeap other) => BinomialHeapUnion(this, other);
        public static BinomialHeap BinomialHeapUnion(BinomialHeap heap1, BinomialHeap heap2)
        {
            BinomialHeap? newHeap = BinomialHeapMerge(heap1, heap2);

            if (newHeap.root == null) return newHeap;

            BTNode? prevNode = null;
            BTNode node = newHeap.root;
            BTNode? nextNode = node.sibling;

            while (nextNode != null)
            {
                if (node.degree != nextNode.degree || (nextNode.sibling != null && nextNode.sibling.degree == node.degree))
                {
                    prevNode = node;
                    node = nextNode;
                }
                else
                {
                    if (node.key <= nextNode.key)
                    {
                        node.sibling = nextNode.sibling;
                        BinomialLink(nextNode, node);
                    }
                    else
                    {
                        if (prevNode == null)
                        {
                            newHeap.root = nextNode;
                        }
                        else
                        {
                            prevNode.sibling = nextNode;
                        }
                        BinomialLink(node, nextNode);
                        newHeap.root = nextNode;
                    }
                }
                nextNode = node.sibling;
            }
            return newHeap;
        }
        public void BinomialHeapInsert(int key) => BinomialHeapInsert(this, new BTNode(key, 0));
        public static void BinomialHeapInsert(BinomialHeap heap, BTNode node)
        {
            BinomialHeap newHeap = new BinomialHeap();
            node.parent = null;
            node.sibling = null;
            node.child = null;
            node.degree = 0;
            newHeap.root = node;
            //
            heap.root = BinomialHeapUnion(heap, newHeap).root;
        }

        public int? BinomialHeapExtractMinKey() => BinomialHeapExtractMin(this)?.key;
        public static BTNode? BinomialHeapExtractMin(BinomialHeap heap)
        {
            if (heap.root == null) return null;
            BTNode? node = heap.root;
            BTNode? minNode = node;
            BTNode? prewNode = null;
            BTNode? newNode;
            while (node != null && node.sibling != null)
            {
                if (node.sibling.key < minNode?.key)
                {
                    minNode = node.sibling;
                    prewNode = node;
                }
                node = node.sibling;
            }
            if (prewNode == null) 
            {
                heap.root = node?.sibling;
            }
            else
            {
                prewNode.sibling = minNode?.sibling;
            }

            newNode = minNode?.child;
            if (newNode != null)
            {
                node = null;
                while (newNode != null)
                {
                    newNode.parent = null;
                    prewNode =  node;
                    node = newNode;
                    newNode = newNode.sibling;
                    node.sibling = prewNode;

                }
            }

            if (heap.root == null)
            {
                heap.root = node;
            }
            else
            {
                BinomialHeapUnion(heap, new BinomialHeap { root = node });
            }
            return minNode;
        }
    }
}

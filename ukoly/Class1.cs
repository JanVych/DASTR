using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ukoly
{
    public class FibonacciHeap
    {
        public FHNode? root;
        public int nodeCount = 0;

        public void FibHeapInsert(int key) => FibHeapInsert(this, new FHNode(key));
        public static void FibHeapInsert(FibonacciHeap heap, FHNode node)
        {
            node.degree = 0;
            node.parent = null;
            node.child = null;
            node.left = node;
            node.right = node;
            node.marked = false;

            if (heap.root != null) 
            {
                heap.root.left.right = node;
                node.right = heap.root;
                node.left = heap.root.left;
                heap.root.left = node;
            }
            else
            {
                heap.root = node;
            }
            heap.nodeCount++;
        }
        public static void FibHeapLink(FHNode node, FHNode y, FHNode z)
        {
            y.left.right = y.right;
            y.right.left = y.left;
            if(z.right == z)
            {
                node = z;
            }
            y.left = y;
            y.right = y;
            y.parent = z;
            if (z.child == null)
            {
                z.child = y;
            }
                
            y.right = z.child;
            y.left = z.child.left;
            z.child.left.right = y;
            z.child.left = y;

            if (y.key < z.child.key)
            {
                z.child = y;
            }  
            z.degree++;
        }
        public FibonacciHeap FibHeapUnion(FibonacciHeap other) => FibHeapUnion(this, other);
        public static FibonacciHeap FibHeapUnion(FibonacciHeap heap1, FibonacciHeap heap2)
        {
            FHNode np;
            FibonacciHeap newHeap = new();

            if (heap1.root == null && heap2.root == null)
            {
                return newHeap;
            }
            if(heap1.root == null)
            {
                newHeap.nodeCount = heap2.nodeCount;
                newHeap.root = heap2.root;
                return newHeap;
            }
            newHeap.root = heap1.root;

            if (heap2.root == null)
            {
                newHeap.nodeCount = heap1.nodeCount;
                return newHeap;
            }

            if (heap1.root.key > heap2.root.key)
            {
                (heap2, heap1) = (heap1, heap2);
            }
            newHeap.nodeCount = heap2.nodeCount + heap1.nodeCount;
            newHeap.root.left.right = heap2.root;
            heap2.root.left.right = newHeap.root;
            np = newHeap.root.left;
            newHeap.root.left = heap2.root.left;
            heap2.root.left = np;
            return newHeap;
        }

        public int? FibHeapExtractMin() => FibHeapExtractMin(this)?.key;
        public static FHNode? FibHeapExtractMin(FibonacciHeap heap)
        {
            if (heap.root != null)
            {
                FHNode p;
                FHNode ptr;
                FHNode z = heap.root;
                p = z;
                ptr = z;    
                FHNode x;
                FHNode np;
                x = null;
                if (z.child != null)
                {
                    x = z.child;
                }  
                if (x != null)
                {
                    ptr = x;
                    do
                    {
                        np = x.right;
                        (heap.root.left).right = x;
                        x.right = heap.root;
                        x.left = heap.root.left;
                        heap.root.left = x;
                        if (x.key < heap.root.key)
                        {
                            heap.root = x;
                        }
                        x.parent = null;
                        x = np;
                    } while (np != ptr);
                }
                (z.left).right = z.right;
                (z.right).left = z.left;
                heap.root = z.right;
                if (z == z.right && z.child == null)
                    heap.root = null;
                else
                {
                    heap.root = z.right;
                    Consolidate(heap, heap.root);
                }
                heap.nodeCount--;
                return p;
            }
            return null;
            
        }

        private static void Consolidate(FibonacciHeap heap,  FHNode mNode)
        {
            if (mNode != null && heap.nodeCount > 0)
            {
                int d, i;

                double phi = (1 + Math.Sqrt(5)) / 2;
                int maxDegree = (int)Math.Floor(Math.Log(heap.nodeCount) / Math.Log(phi));
                

                FHNode[] A = new FHNode[maxDegree + 2];
                for (i = 0; i <= maxDegree; i++)
                    A[i] = null;
                FHNode x = mNode;
                FHNode y;
                FHNode np;
                FHNode pt = x;
                do
                {
                    pt = pt.right;
                    d = x.degree;
                    while (A[d] != null)
                    {
                        y = A[d];
                        if (x.key > y.key)
                        {
                            np = x;
                            x = y;
                            y = np;
                        }
                        if (y == mNode)
                            mNode = x;
                        FibHeapLink(mNode, y, x);
                        if (x.right == x)
                            mNode = x;
                        A[d] = null;
                        d = d + 1;
                    }
                    A[d] = x;
                    x = x.right;
                } while (x != mNode);
                heap.root = null;
                for (int j = 0; j <= maxDegree; j++)
                {
                    if (A[j] != null)
                    {
                        A[j].left = A[j];
                        A[j].right = A[j];
                        if (heap.root != null)
                        {
                            (heap.root.left).right = A[j];
                            A[j].right = heap.root;
                            A[j].left = heap.root.left;
                            heap.root.left = A[j];
                            if (A[j].key < heap.root.key)
                                heap.root = A[j];
                        }
                        else
                        {
                            heap.root = A[j];
                        }
                        if (heap.root == null)
                            heap.root = A[j];
                        else if (A[j].key < heap.root.key)
                            heap.root = A[j];
                    }
                }
            }

        }

        //public static void PrintHeap(FHNode node) 
        //{
        //    FHNode p = node;
        //    if (p == null)
        //    {
        //        Console.WriteLine("Empty Heap");
        //        return;
        //    }
        //    Console.WriteLine("Root Nodes: ");
        //    do
        //    {
        //        Console.Write(p.key);
        //        p = p.right;
        //        if (p != node)
        //        {
        //            Console.Write("-->");
        //        }
        //    } while (p != node && p.right != null);
        //    Console.WriteLine();

        //}

    }
}

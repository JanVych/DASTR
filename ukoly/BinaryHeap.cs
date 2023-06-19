using System.Text;

namespace ukoly
{
    //min-heap
    public class BinaryHeap
    {
        public int[] heap;
        public readonly int heapMaxSize;
        public int heapSize;
        public BinaryHeap(int size)
        {
            heap = new int[size];
            heapMaxSize = size;
            heapSize = 0;
        }

        private static int Parent(int i) => (i - 1) / 2;

        private static int Left(int i) => i * 2 + 1;

        private static int Right(int i) => i * 2 + 2;

        public int? HeapMinimum()
        {
            if (heapSize > 1) { return heap[0]; }
            return null;
        }

        public void MaxHeapify(int parentIndex)
        {
            int leftIndex = Left(parentIndex);
            int rightIndex = Right(parentIndex);
            int largestIndex = parentIndex;
            int swap;

            if ((leftIndex < heapSize) && heap[leftIndex] < heap[largestIndex])
            {
                largestIndex = leftIndex;
            }
            if (rightIndex < heapSize && heap[rightIndex] < heap[largestIndex]) 
            {
                largestIndex = rightIndex;
            }
            if (largestIndex != parentIndex)
            {
                swap = heap[parentIndex];
                heap[parentIndex] = heap[largestIndex];
                heap[largestIndex] = swap;
                MaxHeapify(largestIndex);
            }
        }

        public int? HeapExtractMinimum()
        {
            if (heapSize > 1)
            {
                int max = heap[0];
                heap[0] = heap[heapSize - 1];
                heapSize--;
                MaxHeapify(0);
                return max;
            }
            return null;
        }

        public void HeapDegreseKey(int keyIndex, int key) 
        {
            int swap;
            int parentIndex = Parent(keyIndex);

            if (heap[keyIndex] < key)
            {
                throw new Exception("input key is bigger then target key");
            }

            heap[keyIndex] = key;

            while(keyIndex > 0 && heap[parentIndex] > heap[keyIndex] )
            {
                swap = heap[parentIndex];
                heap[parentIndex] = heap[keyIndex];
                heap[keyIndex] = swap;

                keyIndex = parentIndex;
                parentIndex = Parent(keyIndex);
            }
        }

        public void HeapInsert(int key)
        {
            if (heapSize >= heapMaxSize)
            {
                throw new Exception("heap max size reached");
            }
            heap[heapSize] = int.MaxValue;
            heapSize++;
            HeapDegreseKey(heapSize - 1, key);
        }

        public BinaryHeap HeapUnion(BinaryHeap other)
        {
            BinaryHeap newHeap = new(heapMaxSize + other.heapMaxSize);
            for (int i = 0; i < other.heapSize; i++)
            {
                newHeap.HeapInsert(other.heap[i]);
            }
            for (int i = 0; i < heapSize; i++)
            {
                newHeap.HeapInsert(heap[i]);
            }

            return newHeap;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < heapSize; i++) 
            { 
                sb.Append(heap[i]); 
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }

}

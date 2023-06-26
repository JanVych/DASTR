using ukoly;

Random rnd = new();

int[] values = new int[100_000];

int[] values2 = new int[1_000_000];

int[] values3 = new int[3_000_000];

for (int i = 0; i < values.Length; i++)
{
    values[i] = rnd.Next(1, 1000);
}

for (int i = 0; i < values2.Length; i++)
{
    values2[i] = rnd.Next(1, 1000);
}

for (int i = 0; i < values3.Length; i++)
{
    values3[i] = rnd.Next(1, 1000);
}

BinaryHeap binaryHeap1 = new(values.Length);
BinomialHeap binomialHeap1 = new();
FibonacciHeap fibonacciHeap1 = new();
BinaryHeap binaryHeap2 = new(values2.Length);
BinomialHeap binomialHeap2 = new();
FibonacciHeap fibonacciHeap2 = new();
BinaryHeap binaryHeap3 = new(values3.Length);
BinomialHeap binomialHeap3 = new();
FibonacciHeap fibonacciHeap3 = new();

var watch = System.Diagnostics.Stopwatch.StartNew();
for(int i = 0; i < values.Length; i++)
{
    binaryHeap1.HeapInsert(values[i]);
}
watch.Stop();
Console.WriteLine($"Binary heap 1  insert {values.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values.Length; i++)
{
    binomialHeap1.BinomialHeapInsertKey(values[i]);
}
watch.Stop();
Console.WriteLine($"Binomial heap 1 insert {values.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values.Length; i++)
{
    fibonacciHeap1.FibHeapInsert(values[i]);
}
watch.Stop();
Console.WriteLine($"fibonacci heap 1 insert {values.Length} items in: {watch.ElapsedMilliseconds} ms\n");

///

watch.Restart();
watch.Start();
for (int i = 0; i < values2.Length; i++)
{
    binaryHeap2.HeapInsert(values2[i]);
}
watch.Stop();
Console.WriteLine($"Binary heap 2 insert {values2.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values2.Length; i++)
{
    binomialHeap2.BinomialHeapInsertKey(values2[i]);
}
watch.Stop();
Console.WriteLine($"Binomial heap 2 insert {values2.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values2.Length; i++)
{
    fibonacciHeap2.FibHeapInsert(values2[i]);
}
watch.Stop();
Console.WriteLine($"fibonacci heap 2 insert {values2.Length} items in: {watch.ElapsedMilliseconds} ms\n");

///

watch.Restart();
watch.Start();
for (int i = 0; i < values3.Length; i++)
{
    binaryHeap3.HeapInsert(values3[i]);
}
watch.Stop();
Console.WriteLine($"Binary heap 3 insert {values3.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values3.Length; i++)
{
    binomialHeap3.BinomialHeapInsertKey(values3[i]);
}
watch.Stop();
Console.WriteLine($"Binomial heap 3 insert {values3.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values3.Length; i++)
{
    fibonacciHeap3.FibHeapInsert(values3[i]);
}
watch.Stop();
Console.WriteLine($"fibonacci heap 3 insert {values3.Length} items in: {watch.ElapsedMilliseconds} ms\n");

///

watch.Restart();
watch.Start();
BinaryHeap binaryHeap4 =  binaryHeap1.HeapUnion(binaryHeap2);
watch.Stop();
Console.WriteLine($"binaryHeap1 union binaryHeap2 in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
BinomialHeap binomialHeap4 = binomialHeap1.BinomialHeapUnion(binomialHeap2);
watch.Stop();
Console.WriteLine($"binomialHeap1 union binomialHeap2 in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
FibonacciHeap fibonacciHeap4 = fibonacciHeap1.Union(fibonacciHeap2);
watch.Stop();
Console.WriteLine($"fibonacciHeap1 union fibonacciHeap1 in: {watch.ElapsedMilliseconds} ms\n");

///

watch.Restart();
watch.Start();
for (int i = 0; i < values.Length; i++)
{
    binaryHeap3.HeapExtractMinimum();
}
watch.Stop();
Console.WriteLine($"Binary heap 3 extracted {values.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values.Length; i++)
{
    binomialHeap3.BinomialHeapExtractMinKey();
}
watch.Stop();
Console.WriteLine($"binomial heap 3 extracted {values.Length} items in: {watch.ElapsedMilliseconds} ms");

//

watch.Restart();
watch.Start();
for (int i = 0; i < values.Length; i++)
{
    fibonacciHeap3.FibHeapExtractMin();
}
watch.Stop();
Console.WriteLine($"fibonacci heap 3 extracted {values.Length} items in: {watch.ElapsedMilliseconds} ms\n");

watch.Restart();
watch.Start();
for (int i = 0; i < values2.Length; i++)
{
    binaryHeap3.HeapExtractMinimum();
}
watch.Stop();
Console.WriteLine($"Binary heap 3 extracted {values2.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values2.Length; i++)
{
    binomialHeap3.BinomialHeapExtractMinKey();
}
watch.Stop();
Console.WriteLine($"binomial heap 3 extracted {values2.Length} items in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
for (int i = 0; i < values2.Length; i++)
{
    fibonacciHeap3.FibHeapExtractMin();
}
watch.Stop();
Console.WriteLine($"fibonacci heap 3 extracted {values2.Length} items in: {watch.ElapsedMilliseconds} ms\n");



Console.WriteLine("END");
Console.ReadLine();
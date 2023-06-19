using ukoly;

Random rnd = new();

int[] values = new int[1_00_000];

int[] values2 = new int[10_000_000];

for (int i = 0; i < values.Length; i++)
{
    values[i] = rnd.Next(1, 10000);
}

for (int i = 0; i < values2.Length; i++)
{
    values2[i] = rnd.Next(1, 10000);
}

BinaryHeap binaryHeap1 = new(values.Length);
BinomialHeap binomialHeap1 = new();
FibonacciHeap fibonacciHeap1 = new FibonacciHeap();
BinaryHeap binaryHeap2 = new(values2.Length);
BinomialHeap binomialHeap2 = new();
FibonacciHeap fibonacciHeap2 = new FibonacciHeap();

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
    binomialHeap1.BinomialHeapInsert(values[i]);
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
    binomialHeap2.BinomialHeapInsert(values2[i]);
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
Console.WriteLine($"fibonacci heap 1 insert {values2.Length} items in: {watch.ElapsedMilliseconds} ms\n");

watch.Restart();
watch.Start();
var binaryHeap3 = binaryHeap1.HeapUnion(binaryHeap2);
watch.Stop();
Console.WriteLine($"binaryHeap1 union binaryHeap2 in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
var binomialHeap3 = binomialHeap1.BinomialHeapUnion(binomialHeap2);
watch.Stop();
Console.WriteLine($"binomialHeap1 union binomialHeap2 in: {watch.ElapsedMilliseconds} ms");

watch.Restart();
watch.Start();
var fibonacciHeap3 = fibonacciHeap1.FibHeapUnion(fibonacciHeap2);
watch.Stop();
Console.WriteLine($"fibonacciHeap1 union fibonacciHeap1 in: {watch.ElapsedMilliseconds} ms\n");

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
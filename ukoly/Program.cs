using ukoly;

Random rnd = new();

BinaryHeap h1 = new(10);
BinaryHeap h2 = new(10);
for (int i = 0; i < 8; i++)
{
    int num = rnd.Next(0,100);
    Console.WriteLine("insert:" + num.ToString());
    h1.HeapInsert(num);
    
    Console.WriteLine(h1.ToString());
}

//Console.WriteLine("\nextractmMax:" + h1.HeapExtractMinimum());
Console.WriteLine(h1.ToString());

for (int i = 0; i < 8; i++)
{
    h2.HeapInsert(i);
}
Console.WriteLine(h2.ToString());

Console.WriteLine(h1.HeapUnion(h2).ToString());

//h1.HeapInsert(15);
//Console.WriteLine("\ninsert: 15");
//Console.WriteLine("heapsize: " + h1.heapSize.ToString());
//Console.WriteLine(h1.ToString());

//Console.WriteLine("\nextractmMax:" + h1.HeapExtractMaximum());
//Console.WriteLine("heapsize: " + h1.heapSize.ToString());
//Console.WriteLine(h1.ToString());

//h1.HeapInsert(3);
//Console.WriteLine("\ninsert: 3");
//Console.WriteLine("heapsize: " + h1.heapSize.ToString());
//Console.WriteLine(h1.ToString());

//Console.WriteLine("\nextractmMax:" + h1.HeapExtractMaximum());
//Console.WriteLine("heapsize: " + h1.heapSize.ToString());
//Console.WriteLine(h1.ToString());



Console.ReadLine();
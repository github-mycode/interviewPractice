using System;

namespace HeapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap(10);
            heap.Add(10);
            heap.Add(11);
            heap.Add(1);
            heap.Add(18);

            heap.Add(3);
            heap.Add(14);
            heap.Add(13);
            heap.Add(4);

            heap.Remove(0);
            heap.Remove(0);
            heap.Remove(0);
            heap.Remove(0);

            heap.Remove(0);
            heap.Remove(0);
            heap.Remove(0);
            heap.Remove(0);
            Console.WriteLine("Hello World!");
        }
    }
}

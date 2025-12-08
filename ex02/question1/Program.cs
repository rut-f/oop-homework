using System;

class Program
{
    static void Main()
    {
        try
        {
            // הקצאה מערך קטן
            int[] arr1 = new int[1000];
            Console.WriteLine("Allocated 1000 ints");

            // הקצאה מערך בינוני
            int[] arr2 = new int[100000000]; 
            Console.WriteLine("Allocated 100,000,000 ints");

            // הקצאה מערך גדול
            int[] arr3 = new int[int.MaxValue / 10];
            Console.WriteLine("Allocated very large array");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("OutOfMemoryException: reached practical limit");
        }
    }
}

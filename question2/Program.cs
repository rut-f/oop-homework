namespace ExpandArray
{
    struct MyStruct
    {
        public int X;
        public double Y;
    }
    struct MyBigStruct
    {
        public int X;
        public double Y;
    }
    class SmallClass
    {
        public int X;
    }
    class LargeClass
    {
        public int A, B, C, D, E, F, G, H;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //א.
            // מדידה עבור מערך בגודל 0
            long before1 = GC.GetAllocatedBytesForCurrentThread();
            int[] arr1 = new int[0];
            long after1 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"size of arr1 with 0 elements = {after1 - before1} bytes");

            // מדידה עבור מערך בגודל 5
            long before2 = GC.GetAllocatedBytesForCurrentThread();
            int[] arr2 = new int[5];
            long after2 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"size of arr2 with 5 elements = {after2 - before2} bytes");

            //ב.
            // מדידה עבור מערך בגודל 0
            long beforeStructArr1 = GC.GetAllocatedBytesForCurrentThread();
            MyStruct[] structArr1 = new MyStruct[0];
            long afterStructArr1 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated for empty struct array = {afterStructArr1 - beforeStructArr1} bytes");

            // מדידה עבור מערך בגודל 5
            long beforeStructArr2 = GC.GetAllocatedBytesForCurrentThread();
            MyStruct[] structArr2 = new MyStruct[5];
            long afterStructArr2 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated for struct array with 5 elements = {afterStructArr2 - beforeStructArr2} bytes");

            // מדידה עבור מערך בגודל 5 עם סטראקטים גדולים יותר
            long beforeStructArr3 = GC.GetAllocatedBytesForCurrentThread();
            MyBigStruct[] structArr3 = new MyBigStruct[5];
            long afterStructArr3 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated for struct array with 5 elements = {afterStructArr3 - beforeStructArr3} bytes");

            //ג.
            //מדידה עבור שני מערכים עם מצביעים לגדלים שונים של class
            long beforeStructArr4 = GC.GetAllocatedBytesForCurrentThread();
            SmallClass[] classArr1 = new SmallClass[100];
            long afterStructArr4 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated for SmallClass array with 5 elements = {afterStructArr4 - beforeStructArr4} bytes");

            long beforeStructArr5 = GC.GetAllocatedBytesForCurrentThread();
            LargeClass[] classArr2 = new LargeClass[100];
            long afterStructArr5 = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated for LargeClass array with 5 elements = {afterStructArr5 - beforeStructArr5} bytes");

        }
    }
}




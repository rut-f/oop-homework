using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int n = 100_000_000;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) arr[i] = i;

        Stopwatch sw = new Stopwatch();

        // א. שני תהליכונים ניגשים לאזורים שונים במערך
        sw.Start();
        Thread t1 = new Thread(() => SumRange(arr, 0, n / 2));
        Thread t2 = new Thread(() => SumRange(arr, n / 2, n));
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        sw.Stop();
        Console.WriteLine($"גישה לאזורים שונים: {sw.ElapsedMilliseconds} ms");

        // ב. שני תהליכונים ניגשים לכל המערך
        sw.Restart();
        Thread t3 = new Thread(() => SumRange(arr, 0, n));
        Thread t4 = new Thread(() => SumRange(arr, 0, n));
        t3.Start();
        t4.Start();
        t3.Join();
        t4.Join();
        sw.Stop();
        Console.WriteLine($"גישה לכל המערך: {sw.ElapsedMilliseconds} ms");
    }

    static long SumRange(int[] arr, int start, int end)
    {
        long sum = 0;
        for (int i = start; i < end; i++)
            sum += arr[i];
        return sum;
    }
}

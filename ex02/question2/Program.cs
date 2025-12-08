using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = 100_000_000;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) arr[i] = i;

        Stopwatch sw = new Stopwatch();

        // גישה רציפה
        sw.Start();
        long sum1 = 0;
        for (int i = 0; i < n; i++)
            sum1 += arr[i];
        sw.Stop();
        Console.WriteLine($"גישה רציפה: {sw.ElapsedMilliseconds} ms, sum={sum1}");

        // גישה מרוחקת
        sw.Restart();
        long sum2 = 0;
        for (int i = 0; i < n; i++)
            sum2 += arr[(i * 10) % n];
        sw.Stop();
        Console.WriteLine($"גישה מרוחקת: {sw.ElapsedMilliseconds} ms, sum={sum2}");
    }
}
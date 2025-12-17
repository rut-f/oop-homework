//2
public class ArrayProcessor
{
    public delegate void UnaryAction(double a);

    public static void ProcessArray(double[] array, UnaryAction processor)
    {
        foreach (double value in array)
        {
            processor(value);
        }
    }
}
//3
public class SumCalculator
{
    public double Sum { get; private set; } = 0;

    public void AddToSum(double value)
    {
        Sum += value;
    }
}

public class MaxCalculator
{
    public double Max { get; private set; } = double.MinValue;

    public void CheckMax(double value)
    {
        if (value > Max)
            Max = value;
    }
}
//4
public class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();

        double[] arr = new double[10];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.NextDouble() * 100;
        }

        SumCalculator sc = new SumCalculator();
        MaxCalculator mc = new MaxCalculator();

        ArrayProcessor.ProcessArray(arr, sc.AddToSum);
        ArrayProcessor.ProcessArray(arr, mc.CheckMax);

        Console.WriteLine("Array values:");
        foreach (double v in arr)
            Console.Write(v + " ");
        Console.WriteLine();

        Console.WriteLine("Sum = " + sc.Sum);
        Console.WriteLine("Max = " + mc.Max);

        //5
        double[] arr2 = { 5, 12, 3, 9 };

        double sum = 0;
        double max = double.MinValue;

        ArrayProcessor.ProcessArray(arr2, x => sum += x);

        ArrayProcessor.ProcessArray(arr2, x =>
        {
            if (x > max)
                max = x;
        });

        Console.WriteLine("Sum = " + sum);
        Console.WriteLine("Max = " + max);

    }
}
using System;
using System.Collections.Generic;

// ===================== Fraction =====================
public class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero");

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        Numerator = numerator;
        Denominator = denominator;

        Reduce();
    }

    private static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private void Reduce()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int den = a.Denominator * b.Denominator;
        return new Fraction(num, den);
    }

    public override string ToString()
    {
        return Denominator == 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";
    }
}

// ===================== OperationTable<T> =====================
public class OperationTable<T>
{
    public delegate T OpFunc(T x, T y);

    private List<T> rowValues;
    private List<T> colValues;
    private T[,] table;
    private OpFunc op;

    public OperationTable(List<T> _row_values, List<T> _col_values, OpFunc _op)
    {
        rowValues = _row_values;
        colValues = _col_values;
        op = _op;

        int rows = rowValues.Count;
        int cols = colValues.Count;

        table = new T[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                table[i, j] = op(rowValues[i], colValues[j]);
            }
        }
    }

    public void Print()
    {
        const int width = 12;

        Console.Write("".PadRight(width));
        foreach (var col in colValues)
            Console.Write(col.ToString().PadRight(width));
        Console.WriteLine();

        for (int i = 0; i < rowValues.Count; i++)
        {
            Console.Write(rowValues[i].ToString().PadRight(width));

            for (int j = 0; j < colValues.Count; j++)
                Console.Write(table[i, j].ToString().PadRight(width));

            Console.WriteLine();
        }
    }
}

// ===================== Program (question 5) =====================
public class Program
{
    public static void Main(string[] args)
    {
        // יצירת רשימת שברים 1/12 עד 12/12
        List<Fraction> values = new List<Fraction>();
        for (int i = 1; i <= 12; i++)
            values.Add(new Fraction(i, 12));

        // יצירת טבלת חיבור של שברים
        OperationTable<Fraction> table =
            new OperationTable<Fraction>(values, values, (a, b) => a + b);

        // הדפסה
        table.Print();
    }
}
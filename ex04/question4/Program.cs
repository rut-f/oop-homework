using System;

public class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    // --- Constructor ---
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero");

        // מכנה חיובי
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        Numerator = numerator;
        Denominator = denominator;

        Reduce(); // צמצום אוטומטי
    }

    // --- GCD (אלגוריתם אוקלידס) ---
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

    // --- צמצום השבר ---
    private void Reduce()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    // --- Operator + ---
    public static Fraction operator +(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int den = a.Denominator * b.Denominator;
        return new Fraction(num, den);
    }

    // --- Operator - ---
    public static Fraction operator -(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int den = a.Denominator * b.Denominator;
        return new Fraction(num, den);
    }

    // --- Operator * ---
    public static Fraction operator *(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Numerator;
        int den = a.Denominator * b.Denominator;
        return new Fraction(num, den);
    }

    // --- Operator / ---
    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by zero fraction");

        int num = a.Numerator * b.Denominator;
        int den = a.Denominator * b.Numerator;
        return new Fraction(num, den);
    }

    // --- השוואות < ו > ---
    public static bool operator <(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    // --- השוואות == ו != ---
    public static bool operator ==(Fraction a, Fraction b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

        return a.Numerator == b.Numerator &&
               a.Denominator == b.Denominator;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    // חובה כשמגדירים == ו !=
    public override bool Equals(object obj)
    {
        if (obj is Fraction other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    // --- ToString ---
    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(1, 3);

        Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
        Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
        Console.WriteLine($"{f1} / {f2} = {f1 / f2}");

        Console.WriteLine($"{f1} < {f2}  → {f1 < f2}");
        Console.WriteLine($"{f1} > {f2}  → {f1 > f2}");
        Console.WriteLine($"{f1} == {f2} → {f1 == f2}");
        Console.WriteLine($"{f1} != {f2} → {f1 != f2}");
    }
}

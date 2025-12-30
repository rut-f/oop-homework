

class Program
{

    //א
    public delegate double BinaryOperation(double x, double y);
    //ב
    public static double Add(double x, double y)
    {
        return x + y;
    }
    public static double Subtract(double x, double y)
    {
        return x - y;
    }
    public static double Multiply(double x, double y)
    {
        return x * y;
    }
    //ג
    public static double ApplyOperation(BinaryOperation bOp, double a, double b)
    {
        return bOp(a, b);
    }

}
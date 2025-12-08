
class MyClass
{
    public int Value;
}

struct MyStruct
{
    public int Value;
}

class Program
{
    static void Main()
    {
        //א.
        // a.
        MyClass a = new MyClass { Value = 10 };
        MyClass b = a;
        b.Value = 20;
        Console.WriteLine($"Class a.Value = {a.Value}");

        MyStruct x = new MyStruct { Value = 10 };
        MyStruct y = x;
        y.Value = 20;
        Console.WriteLine($"Struct x.Value = {x.Value}");

        //b.
        static void ChangeClass(MyClass obj)
        {
            obj.Value = 100;
        }

        static void ChangeStruct(MyStruct obj)
        {
            obj.Value = 100;
        }

        MyClass c = new MyClass { Value = 10 };
        ChangeClass(c);
        Console.WriteLine($"Class c.Value = {c.Value}"); 

        MyStruct s = new MyStruct { Value = 10 };
        ChangeStruct(s);
        Console.WriteLine($"Struct s.Value = {s.Value}");

        //ב.
        static void ChangeStructReal(ref MyStruct s)
        {
            s.Value = 999;
        }

        MyStruct r = new MyStruct { Value = 90 };
        ChangeStructReal(ref r);
        Console.WriteLine($"Struct s.Value = {s.Value}");
    }
}

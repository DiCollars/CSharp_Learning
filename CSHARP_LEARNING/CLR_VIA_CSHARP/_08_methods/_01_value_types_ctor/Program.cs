internal class Program
{
    private static void Main(string[] args)
    {
        MyStruct test = new MyStruct(5);

        Console.WriteLine(test.a + " " + test.b);

        test.a = 10;

        Console.WriteLine(test.a + " " + test.b);
    }
}

struct MyStruct
{
    public int a;
    public int b;

    public MyStruct()
    {
        a = b = 0;
    }

    public MyStruct(int val)
    {
        //this = new MyStruct();
        a = val;
    }
}

//struct MyStruct
//{
//    public int a = 5; // CS8983 - A 'struct' with field initializers must include an explicitly declared constructor.
//}
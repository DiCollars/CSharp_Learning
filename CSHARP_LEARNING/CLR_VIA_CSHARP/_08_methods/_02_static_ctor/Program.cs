var valc = new SuperClass();
var vals = new SuperStruct();

Console.WriteLine(SuperClass.data);
Console.WriteLine(SuperStruct.data);

class SuperClass
{
    public static string data;

    static SuperClass()
    {
        data = "class";
        Console.WriteLine("SuperClass static ctor");
    }
}

struct SuperStruct
{
    public static string data;

    static SuperStruct()
    {
        data = "struct";
        Console.WriteLine($"SuperStruct static ctor");
    }
}
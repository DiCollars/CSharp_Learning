using System;
namespace Check
{

public sealed class Checker
{
    delegate void AccountHandler(string message);
    event AccountHandler Notify;

    public static void Main()
    {
        Console.WriteLine("Start!");
        Console.ReadKey();
    }

    public Checker(int prop, int field)
    {
        Property = prop;
        this.field = field;
    }

    public int field;

    public int Property { get; set; }

    public void DisplayStatus(bool showField = true)
    {
        if (showField)
        {
            Console.WriteLine(field);
        }
        else
        {
            Console.WriteLine(Property);   
        }
    }

    public void Put(int sum)    
    {
        Console.WriteLine(sum);
    }
}

}